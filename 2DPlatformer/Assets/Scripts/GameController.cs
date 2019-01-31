using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public Animator cameraAnim;
    private int animViewHash;
    private int subStageCount;

	// Use this for initialization
	void Start () {
        subStageCount = 0;
        animViewHash = Animator.StringToHash("ViewNumber");
	}

    public void ChangeSubStage(int subStageID)
    {
        subStageCount = subStageID;
        cameraAnim.SetInteger(animViewHash, subStageCount);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
