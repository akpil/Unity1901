using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    private Animator anim;
    private int animMoveHash;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        animMoveHash = Animator.StringToHash("IsMove");
	}

    public void StartMove()
    {
        anim.SetBool(animMoveHash, true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
