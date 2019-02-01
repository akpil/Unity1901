using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    private Animator anim;
    
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public void StartMove()
    {
        anim.SetBool(AnimHash.Move, true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
