using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public PlatformController platformController;
    public float HP;

    public void Hit(float damage)
    {
        Debug.Log(damage);
        HP -= damage;

        if(HP <= 0)
        {
            StartCoroutine(waiter());
        }
    }

    private IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        if (HP == 0)
        {
            platformController.StartMove();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
