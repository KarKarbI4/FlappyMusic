using UnityEngine;
using System.Collections;

public class Equalizer : MonoBehaviour {

    private GameObject col;
    public GameObject[] eq;
    public int eqLength;

	// Use this for initialization
	void Start () {
        col = Resources.Load("Prefabs/Rect") as GameObject;
        eq = new GameObject[eqLength];
        for (int i = 0; i < eqLength; ++i) {
            eq[i] = Instantiate(col, Vector2.zero, Quaternion.identity) as GameObject;
            //eq[i].transform.parent = transform;
            eq[i].transform.position = (Vector2) eq[i].transform.position + new Vector2(i * eq[i].GetComponent<BoxCollider>().bounds.size.x, 0);
        }
	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
