using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoker : MonoBehaviour {
    private Rigidbody rb;

    private GameObject target;
    public GameObject effectPrefab;
    public Item itemPrefab;
    public float Speed;
    public float Torque;
	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.onUnitSphere * Torque;
        rb.velocity = Vector3.back * Speed;
        target = GameObject.FindGameObjectWithTag("Player");
	}

    private void Start()
    {
        StartCoroutine(stoking());
    }

    private IEnumerator stoking()
    {
        while (target != null)
        {
            Vector3 dir = (target.transform.position - transform.position).normalized;
            rb.velocity = dir * Speed;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void AddSpeed(float amount)
    {
        Speed += amount;
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
    // Update is called once per frame
    void Update () {
		
	}
}
