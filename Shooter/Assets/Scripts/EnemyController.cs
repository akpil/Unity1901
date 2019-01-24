using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform boltPosition;
    public Bolt enemyBolt;

    private Rigidbody rb;
    public float Speed;

    private SoundController sound;

    public GameObject effectPrefab;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Speed;
        GameObject soundObj = GameObject.FindGameObjectWithTag("SoundController");
        sound = soundObj.GetComponent<SoundController>();

        StartCoroutine(enemyFire());
        StartCoroutine(enemyMovement());
	}

    public void AddSpeed(float amount)
    {
        Speed += amount;
        rb.velocity = transform.forward * Speed;
    }

	// Update is called once per frame
	void Update () {
		
	}
    private IEnumerator enemyMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            if (transform.position.x < 0)
            {
                rb.velocity += Vector3.right * Random.Range(1.5f, 3);
            }
            else
            {
                rb.velocity += Vector3.left * Random.Range(1.5f, 3);
            }
            yield return new WaitForSeconds(1);
            rb.velocity -= new Vector3(rb.velocity.x, 0, 0);
        }
    }
    private IEnumerator enemyFire()
    {
        while (true)
        {
            Bolt newBolt = Instantiate(enemyBolt);
            sound.PlayEffect(3);
            newBolt.transform.position = boltPosition.position;
            yield return new WaitForSeconds(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("PlayerBolt"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            sound.PlayEffect(1);

            GameObject effect = Instantiate(effectPrefab);
            effect.transform.position = transform.position;

            GameObject controlObj = GameObject.FindGameObjectWithTag("GameController");
            GameController controller = controlObj.GetComponent<GameController>();
            controller.AddScore(20);
        }
    }
}
