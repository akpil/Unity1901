using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMan : MonoBehaviour
{
    private int hitCount;
    public Transform ItemPos;
    public Item itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
    }
    public void Hit(float damage)
    {
        hitCount++;
        if (hitCount >= 3)
        {
            Item item = Instantiate(itemPrefab);
            item.transform.position = ItemPos.position;
            hitCount = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
