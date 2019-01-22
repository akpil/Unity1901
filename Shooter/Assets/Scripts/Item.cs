using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    private Rigidbody rb;
    public float Torque;
    public float Speed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.onUnitSphere * Torque;
        rb.velocity = Vector3.back * Speed;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
