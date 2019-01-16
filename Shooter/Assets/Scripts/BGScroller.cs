using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    private Rigidbody rb;
    public float Speed;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * Speed;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BGBumper"))
        {
            transform.position += Vector3.forward * (40.94f);

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
