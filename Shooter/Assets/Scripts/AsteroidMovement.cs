using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    private Rigidbody rb;
    public float Torque;
    public float Speed;
    public GameObject effectPrefab;


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

            SoundController sound = (GameObject.FindGameObjectWithTag("SoundController")).GetComponent<SoundController>();
            sound.PlayEffect(0);

            GameObject effect = Instantiate(effectPrefab);
            effect.transform.position = transform.position;

            GameObject controlObj = GameObject.FindGameObjectWithTag("GameController");
            GameController controller = controlObj.GetComponent<GameController>();
            controller.AddScore(10);
        }
    }
}
