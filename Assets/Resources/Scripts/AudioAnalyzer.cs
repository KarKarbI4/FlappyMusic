using UnityEngine;
using System.Collections;

public class AudioAnalyzer : MonoBehaviour {

    public const float heightMul = 100.0f;
    public const float downSpeed = 0.01f;

    private const int specSize = 1024;
    AudioClip track;
    AudioSource audioSource;
    GameObject[] eqlArray;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) {
            Debug.Log("There is no audioSource attached");
            GameObject.Destroy(gameObject);
        }
        track = audioSource.clip;
        float[] samples = new float[audioSource.clip.samples];
        if (audioSource.clip.GetData(samples, 0)) {
            Debug.Log("ok");
        } else {
            Debug.Log("now ok");
        }
        Debug.Log(samples.GetLength(0));
        eqlArray = GameObject.FindGameObjectsWithTag("Equalizer");
        
	}

    void getBeat()
    {
        //audioSource.GetSpectrumData();
    }
	// Update is called once per frame
    void Update()
    {
        float[] spectrum = new float[1024];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        int i = 1;
        while (i < specSize)
        {
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] * 10 - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] * 10 - 10, 1), Color.green);
            i++;
        }
        foreach (GameObject eql in eqlArray)
        {
            GameObject[] colArr = eql.GetComponent<Equalizer>().eq;
            for (int j = 0; j < specSize; ++j) {
                int colIndex = j * colArr.Length / specSize;
                float newHeight = spectrum[j] * heightMul;
                if (newHeight > colArr[colIndex].transform.localScale.y - downSpeed) {
                    colArr[colIndex].transform.localScale = new Vector3(colArr[colIndex].transform.localScale.x, newHeight, colArr[colIndex].transform.localScale.z);
                } else {
                    colArr[colIndex].transform.localScale = new Vector3(colArr[colIndex].transform.localScale.x, colArr[colIndex].transform.localScale.y - downSpeed, colArr[colIndex].transform.localScale.z);
                }
                colArr[colIndex].transform.localPosition = new Vector3(colArr[colIndex].transform.position.x, colArr[colIndex].transform.localScale.y / 2, colArr[colIndex].transform.position.z);
            }
        }
    }

}