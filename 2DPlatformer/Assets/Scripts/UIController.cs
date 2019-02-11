using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text timeText;
    public HPBar HPbarPrefab;
    public Image PlayerHPBar;
	// Use this for initialization
	void Start () {
        timeText.text = "0.0";
    }

    public void ShowPlayerHP(float hp)
    {
        PlayerHPBar.fillAmount = hp;
    }

    public HPBar GetHPBar()
    {
        return Instantiate(HPbarPrefab, transform);
    }

    public void ShowTime(float time)
    {
        timeText.text = time.ToString("f2");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

