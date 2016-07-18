using UnityEngine;
using System.Collections;

public class birdController : plane {
    void gamepad() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
    }

    protected override void controls_update() {
        if (Input.GetKey(KeyCode.Mouse0)) {
            shoot();
        }
        Debug.DrawRay(transform.position, transform.rotation * new Vector2(-1, 0) * 20, Color.cyan);
    }
}