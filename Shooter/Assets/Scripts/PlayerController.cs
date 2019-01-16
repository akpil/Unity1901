using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Transform boltPosition;
    public Bolt boltPrefab;
    public float fireRate;
    private float currentFireRate;

    private Rigidbody rb;
    public float Speed;
    public float Tilt;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        currentFireRate = 0;
    }
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal, 0, vertical) * Speed;

        rb.rotation = Quaternion.Euler(new Vector3(0, 0, -horizontal * Tilt));

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax),
                                  0,
                                  Mathf.Clamp(rb.position.z, zMin, zMax));

        if (Input.GetButton("Fire1") && currentFireRate <= 0)
        {
            Bolt newBolt = Instantiate(boltPrefab);
            newBolt.transform.position = boltPosition.position;
            currentFireRate = fireRate;
        }
        currentFireRate -= Time.deltaTime;
	}
}
