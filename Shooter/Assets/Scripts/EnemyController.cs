using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform boltPosition;
    public Bolt enemyBolt;

    private Rigidbody rb;
    public float Speed;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Speed;
        StartCoroutine(enemyFire());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator enemyFire()
    {
        while (true)
        {
            Bolt newBolt = Instantiate(enemyBolt);
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
            // 점수를 올린다.
            GameObject controlObj = GameObject.FindGameObjectWithTag("GameController");
            GameController controller = controlObj.GetComponent<GameController>();
            controller.AddScore(10);
        }
    }
}
