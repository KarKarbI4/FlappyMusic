using UnityEngine;
using System.Collections;

public class PlaneShoot : MonoBehaviour {

    public GameObject bullet;
    public float bulletVelocity;

    private Vector3 bulletOffset;
    // Use this for initialization
    void Start () {
        bulletOffset = new Vector3(3, 0);        
	}

    public void Shoot() {
        GameObject clone = Instantiate(bullet) as GameObject;
        clone.transform.position = transform.position + transform.rotation * bulletOffset;
        clone.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2(bulletVelocity, 0);
        clone.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
