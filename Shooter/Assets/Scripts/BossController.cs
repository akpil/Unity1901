using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MovePhase());
	}

    private IEnumerator MovePhase()
    {
        rb.velocity = transform.forward * 2;
        while (transform.position.z > 10)
        {
            yield return new WaitForSeconds(0.1f);
        }
        rb.velocity = Vector3.zero;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
