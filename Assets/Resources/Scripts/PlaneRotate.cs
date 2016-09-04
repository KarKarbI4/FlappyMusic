using UnityEngine;
using System.Collections;

public class PlaneRotate : MonoBehaviour {
    public float rotSpeed;
    public Transform target;
    public bool mouse;
    // Use this for initialization
    void Start () {

	}
	
    void Rotate(Vector3 targetPos) {
        Vector3 vectorToTarget = targetPos - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotSpeed);
    }

    Vector3 getMousePos() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (mouse) {
            Rotate(getMousePos());
        } else {
            Rotate(target.position);
        }

    }
}
