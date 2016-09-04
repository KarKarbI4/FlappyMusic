using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    private PlaneShoot planeShoot;
    private PlaneBarrelRoll planeRoll;

    // Use this for initialization
    void Start () {
        planeShoot = gameObject.GetComponent<PlaneShoot>();
        planeRoll = gameObject.GetComponent<PlaneBarrelRoll>();
	}

	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButton(0)) {
            planeShoot.Shoot();
        }
        if (Input.GetMouseButtonDown(1)) {
            planeRoll.Roll();
        }
	}
}
