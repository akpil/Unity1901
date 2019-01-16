using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    private Rigidbody rb;
    public float Torque;
    public float Speed;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.onUnitSphere * Torque;
        rb.velocity = Vector3.back * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("PlayerBolt"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            // 점수를 올린다.
        }
    }
}
