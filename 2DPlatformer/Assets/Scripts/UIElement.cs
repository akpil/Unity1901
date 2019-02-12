﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElement : MonoBehaviour
{
    public Image icon;
    public Text title;
    public Text cost;
    public Text contents;
    public Text purchase;



    // Start is called before the first frame update
    void Start()
    {
        //title.text = "이름공간";
        cost.text = "가격공간";
        contents.text = "상세설명이 들어가는 공간 두줄 이상의 데이터가 들어갈 수 있음";
        purchase.text = "구매";
    }

    public void SetTitle(string name)
    {
        title.text = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
