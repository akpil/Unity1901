using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {
    public Image bar;
    public void ShowHP(float percent)
    {
        bar.fillAmount = percent;
    }
}
