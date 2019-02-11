using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    public float time;

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyAfter()); 
	}

    private IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
