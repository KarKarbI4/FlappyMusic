using UnityEngine;
using System.Collections;

public class playerCamera : MonoBehaviour {

	public GameObject objToFollow;
    public float xOffset;
    bool stop;

	// Use this for initialization
	void Start () {
        stop = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!stop)
        {
            transform.position = new Vector3(objToFollow.transform.position.x + xOffset, transform.position.y, transform.position.z);
        }
        

	}

    void Stop()
    {
        if (!stop)
        {
            transform.position -= new Vector3(0, 0, 0);
            stop = true;
        }
    }
}
