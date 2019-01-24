using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    private Rigidbody rb;
    public float Torque;
    public float Speed;
    public GameObject effectPrefab;
    public Item itemPrefab;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.onUnitSphere * Torque;
        rb.velocity = Vector3.back * Speed;
    }

    public void AddSpeed(float amount)
    {
        Speed += amount;
        rb.velocity = transform.forward * Speed;
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

            float rate = Random.Range(0.0f, 1f);
            if (rate < 0.25f)
            {
                Item newItem = Instantiate(itemPrefab);
                newItem.transform.position = transform.position;
            }

            GameObject effect = Instantiate(effectPrefab);
            effect.transform.position = transform.position;

            GameObject controlObj = GameObject.FindGameObjectWithTag("GameController");
            GameController controller = controlObj.GetComponent<GameController>();
            controller.AddScore(10);
        }
    }
}
