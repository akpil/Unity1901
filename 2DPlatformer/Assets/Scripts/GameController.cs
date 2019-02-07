using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public Animator cameraAnim;
    
    private int subStageCount;

    private int Score;

	// Use this for initialization
	void Start () {
        subStageCount = 0;
        Score = 0;
    }

    public void ChangeSubStage(int subStageID)
    {
        subStageCount = subStageID;
        cameraAnim.SetInteger(AnimHash.View, subStageCount);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        StartCoroutine(CameraMove());
    }

    private IEnumerator CameraMove()
    {
        yield return new WaitForSeconds(10);

        if (Score >= 1)
        {
            subStageCount++;
            cameraAnim.SetInteger(AnimHash.View, subStageCount);
        }
    }

    public void GameFinish()
    {
        Debug.Log("Game Finish");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
