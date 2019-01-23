using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public Bolt bossBoltPrefab;
    public Transform boltPosition;
    private Coroutine fireRoutine;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MovePhase());
        currentHP = MaxHP;

    }

    private IEnumerator Fire()
    {
        while (true)
        {
            Bolt newBolt = Instantiate(bossBoltPrefab);
            newBolt.transform.position = boltPosition.position;

            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator MovePhase()
    {
        rb.velocity = transform.forward * 2;
        while (transform.position.z > 10)
        {
            yield return new WaitForSeconds(0.1f);
        }
        rb.velocity = Vector3.zero;

        fireRoutine = StartCoroutine(Fire());
        rb.velocity = transform.right * 2;
        while (true)
        {
            yield return new WaitForSeconds(2f);
            rb.velocity = Vector3.zero;
            StopCoroutine(fireRoutine);

            yield return new WaitForSeconds(0.5f);

            fireRoutine = StartCoroutine(Fire());
            rb.velocity = transform.right * -2;
            yield return new WaitForSeconds(4f);
            rb.velocity = Vector3.zero;
            StopCoroutine(fireRoutine);

            yield return new WaitForSeconds(0.5f);

            fireRoutine = StartCoroutine(Fire());
            rb.velocity = transform.right * 2;
            yield return new WaitForSeconds(2f);
        }
    }

    public int MaxHP;
    private int currentHP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBolt"))
        {
            // 체력감소
            currentHP--;
            Debug.Log(currentHP);
            if (currentHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
