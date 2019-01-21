using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimer : MonoBehaviour {
    public float timeOut;
	// Use this for initialization
	void Start () {
        StartCoroutine(WaitAndDestroy());
	}

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(timeOut);
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
