using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    public EnemyController zombiePrefab;
    public Transform spawnPos;
    public Transform timePos;
    public Text time;
    public int Count;
    private int currentCount;
    public float Countdown;
    private float currentCountdown;
    // Start is called before the first frame update
    void Start()
    {
        currentCount = Count;
        currentCountdown = Countdown;
    }

    public void ReduceCount()
    {
        currentCount--;
        time.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Count > currentCount)
        {
            currentCountdown -= Time.deltaTime;
            if (currentCountdown > 0)
            {
                time.text = currentCountdown.ToString("f2");
                time.gameObject.transform.position = timePos.position;
            }
            else
            {
                currentCount++;
                currentCountdown = Countdown;
                EnemyController e = Instantiate(zombiePrefab);
                e.transform.position = spawnPos.position;
            }
        }
        else
        {
            time.gameObject.SetActive(false);
        }
    }
}
