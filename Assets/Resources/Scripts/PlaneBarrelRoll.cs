using UnityEngine;
using System.Collections;

public class PlaneBarrelRoll : MonoBehaviour {
    public float rollSpeed;

    private bool reversed;
    // Use this for initialization
    void Start () {
        reversed = false;
    }
	
    public void Roll () {
        int angle = 180;
        transform.RotateAround(transform.position, transform.right, angle);
        reversed = !reversed;
    }

	// Update is called once per frame
	void Update () {
    }
}
