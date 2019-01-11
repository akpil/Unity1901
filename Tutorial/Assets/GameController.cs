using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private int score;

    public UIController uIController;

	// Use this for initialization
	void Start () {
        score = 0;
        uIController.ShowScore(score);
    }

    public void AddScore()
    {
        score++;
        uIController.ShowScore(score);
        if (score >= 7)
        {
            uIController.ShowClearText();
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
