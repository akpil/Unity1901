using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text ScoreText;
    public Text ClearText;
	// Use this for initialization
	void Start () {
        ClearText.text = "";

    }
    public void ShowScore(int value)
    {
        ScoreText.text = "Score : " + value.ToString();
    }

    public void ShowClearText()
    {
        ClearText.text = "Game Clear!!";
    }

	// Update is called once per frame
	void Update () {
		
	}
}
