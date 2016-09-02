using UnityEngine;
using System.Collections;

public class plane : MonoBehaviour {
    public float horSpeed;
    public float rotSpeed;


    public GameObject bullet;
    private float xrot;
    private bool reversed;
    private Rigidbody2D rb;
	// Use this for initialization
    void Start() {
        reversed = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.Log("There is no Rigidbody attached " + gameObject);
        }
    }

    void FixedUpdate() {
        processRotation();
        rb.velocity = transform.rotation * new Vector2(horSpeed * Time.deltaTime, 0);
    }

    protected void shoot()
    {
        GameObject clone = Instantiate(bullet) as GameObject;
        clone.transform.position = transform.position +transform.rotation * new Vector3(-3, 0);
        clone.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2(-1, 0) * 150;
        clone.transform.rotation = transform.rotation;
    }

    void gamepad() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
    }

    void processRotation() {
        Vector3 targetPos = getTargetPos();
        Vector3 aimDir = (targetPos - transform.position).normalized;
        Debug.DrawLine(transform.position, targetPos);
        //Debug.DrawRay(transform.position, aimDir);
        //Quaternion rotToTarget = Quaternion.LookRotation(aimDir, Vector3.forward) * Quaternion.AngleAxis(-90, Vector3.left) * Quaternion.AngleAxis(90, Vector3.back);
        //Debug.DrawRay(transform.position, rotToTarget * new Vector2(-1, 0), Color.green);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotToTarget, Time.deltaTime * rotSpeed);

        Vector3 vectorToTarget = targetPos - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotSpeed);

        Debug.Log("targetPos" + targetPos);
        
        //Quaternion mouseRot = Quaternion.AngleAxis(xrot, Vector3.left) * Quaternion.AngleAxis(-90, Vector3.forward) * Quaternion.LookRotation(Vector3.forward, target - transform.position);
        //if (reversed)
        //{
        //    mouseRot *= Quaternion.AngleAxis(2 * mouseRot.eulerAngles.z, Vector3.back);
        //}
        
        //transform.rotation = Quaternion.Slerp(transform.rotation, mouseRot, Time.deltaTime * rotSpeed);
        
        //Debug.DrawLine(new Vector3(0, 0, 0), transform.position);
    }

    protected virtual void controls_update()
    {
        
    }

    protected virtual Vector3 getTargetPos() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
        //return new Vector3(100.0f, 120.0f, 0.0f);
    }

	// Update is called once per frame
    void Update()
    {
        controls_update();
        getTargetPos();
        //processRotation();
        if (Input.GetMouseButtonDown(1))
        {
            if (reversed)
            {
                xrot = 0;
                reversed = false;
            }
            else
            {
                xrot = 180;
                reversed = true;
            }
        }
    }
}
