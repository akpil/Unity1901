using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text ScoreText;
    public Text GameOverText;
    public Text RestartText;

	// Use this for initialization
	void Start () {
        ScoreText.text = "Score : 0";
        GameOverText.text = "";
        RestartText.gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        GameOverText.text = "Game Over!";
        RestartText.gameObject.SetActive(true);
    }

    public void HideGameOver()
    {
        GameOverText.text = "";
        RestartText.gameObject.SetActive(false);
    }

    public void ShowScore(int score)
    {
        ScoreText.text = "Score : " + score.ToString();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
