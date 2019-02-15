using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text timeText;
    public HPBar HPbarPrefab;
    public HPBar BossHPbarPrefab;
    public MessageBox MessageBoxPrefab;
    public Image PlayerHPBar;

    public GameObject ResultWindow;
    public Text ResultText;
    public Text PlayTimeText; 

	// Use this for initialization
	void Start () {
        timeText.text = "0.0";
    }

    public void ShowPlayerHP(float hp)
    {
        PlayerHPBar.fillAmount = hp;
    }

    public void ShowMessageBox(string data)
    {
        MessageBox box =  Instantiate(MessageBoxPrefab, transform);
        box.SetText(data);
    }

    public HPBar GetHPBar(bool isBoss)
    {
        if (isBoss)
        {
            return Instantiate(BossHPbarPrefab, transform);
        }
        else
        {
            return Instantiate(HPbarPrefab, transform);
        }
    }

    public void ShowTime(float time)
    {
        timeText.text = time.ToString("f2");
    }
	
    public void ShowResultWindow(string gameStatus, float time)
    {
        ResultText.text = gameStatus;
        PlayTimeText.text = time.ToString("f2");
        ResultWindow.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
		
	}
}

