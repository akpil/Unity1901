using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text ScoreText;
    public Text GameStatusText;
    public Text RestartText;

    public GameObject HpBarBorder;
    public Image HpBar;

	// Use this for initialization
	void Start () {
        ScoreText.text = "Score : 0";
        RestartText.gameObject.SetActive(false);
    }
    public void ShowHP(float amount)
    {
        HpBar.fillAmount = amount;
    }
    public void ShowHPBar()
    {
        HpBarBorder.SetActive(true);
    }
    public void HideHPBar()
    {
        HpBarBorder.SetActive(false);
    }

    public void ShowStatus(string input)
    {
        Debug.Log(input);
        GameStatusText.text = input;
    }

    public void ShowGameOver()
    {
        GameStatusText.text = "Game Over!";
        RestartText.gameObject.SetActive(true);
    }

    public void HideGameOver()
    {
        GameStatusText.text = "";
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
