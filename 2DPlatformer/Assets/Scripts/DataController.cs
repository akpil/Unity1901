using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    int[] a;
    public string[] titles;
    public string test;
    public UIElement[] elements;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].SetTitle(titles[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
