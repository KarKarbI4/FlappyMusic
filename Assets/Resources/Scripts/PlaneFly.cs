using UnityEngine;
using System.Collections;

public class PlaneFly : MonoBehaviour {
    public float horSpeed;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null) {
             Debug.Log("There is no Rigidbody attached to " + gameObject);
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = transform.rotation * new Vector2(horSpeed * Time.deltaTime, 0);
    }
}
