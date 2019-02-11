using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Animator cameraAnim;
    
    private int subStageCount;

    private int Score;

    private UIController uiCont;
    private float playTime;
    private bool isPlay;
	// Use this for initialization
	void Start () {
        subStageCount = 0;
        Score = 0;
        uiCont = GameObject.FindGameObjectWithTag("UI")
                .GetComponent<UIController>();
        playTime = 0;
        isPlay = true;
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

    public void SetSpeed(float speed)
    {
        Time.timeScale = speed;
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
        isPlay = false;
        uiCont.ShowResultWindow("Game Clear!!", playTime);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        isPlay = false;
        uiCont.ShowResultWindow("Game Over!!", playTime);
    }

    public void ReStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update () {
		if(isPlay)
        {
            playTime += Time.deltaTime;
            uiCont.ShowTime(playTime);
        }
	}
}
