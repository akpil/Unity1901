using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public Data[] datas;
    public UIElement[] elements;
    public Sprite[] icons;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(string.Format("{0}번째에 들어있는 자리에 {1}식의 데이터를 넣습니다.{0}",
                                "첫", 260.ToString()));

        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].SetAll(icons[i], datas[i].name, datas[i].contents, datas[i].cost, datas[i].value);
        }
    }

    public void LevelUP(int id)
    {
        datas[id].level++;
        datas[id].cost = datas[id].baseCost * datas[id].level;
        datas[id].value++;
        elements[id].Renew(datas[id].contents, datas[id].cost, datas[id].value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class Data
{
    public string name;
    public string contents;
    public float cost;
    public float baseCost;
    public int level;
    public int value;
}