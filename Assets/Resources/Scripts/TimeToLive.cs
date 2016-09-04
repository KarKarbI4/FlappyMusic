using UnityEngine;
using System.Collections;

public class TimeToLive : MonoBehaviour {
    public float ttl;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, ttl);
    }
	
	// Update is called once per frame
	void Update () {
    }
}
