using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public AsteroidMovement[] astroidPrefab;

    private int Score;

    public float SpawnRate;
    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnEnemy());
        Score = 0;
        Debug.Log(Score);
    }

    public void AddScore(int value)
    {
        Score += value;
        Debug.Log(Score);
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < 20; i++)
            {
                int index = Random.Range(0, astroidPrefab.Length);
                AsteroidMovement newAst = Instantiate(astroidPrefab[index]);
                newAst.transform.position = new Vector3(Random.Range(-5.5f, 5.5f), 0, 16);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(SpawnRate);
        }
    }

	// Update is called once per frame
	void Update () {
    }
}
