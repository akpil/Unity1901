using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public AsteroidMovement[] astroidPrefab;
    public EnemyController enemyShipPrefab;

    public UIController uiController;

    public BGScroller bg1;
    public BGScroller bg2;

    private int Score;

    public float SpawnRate;

    private Coroutine enemy;

    // Use this for initialization
    void Start () {
        enemy = StartCoroutine(SpawnEnemy());
        Score = 0;

    }

    public void AddScore(int value)
    {
        Score += value;
        uiController.ShowScore(Score);
    }

    public void GameOver()
    {
        //적 그만나오기
        StopCoroutine(enemy);
        //배경 멈추기
        bg1.StopMove();
        bg2.StopMove();
        //game  over 알려주기
        uiController.ShowGameOver();
        //다시시작 활성화 하기
    }

    private IEnumerator SpawnEnemy()
    {
        int AstCount = 10;
        int EnemyCount = 5;
        while (true)
        {
            if (AstCount > 0 && EnemyCount > 0)
            {
                int randValue = Random.Range(0, 2);
                if (randValue == 0)
                {
                    int index = Random.Range(0, astroidPrefab.Length);
                    AsteroidMovement newAst = Instantiate(astroidPrefab[index]);
                    newAst.transform.position = new Vector3(Random.Range(-5.5f, 5.5f), 0, 16);
                    AstCount--;
                    yield return new WaitForSeconds(0.5f);
                }
                else
                {
                    EnemyController newEnemy = Instantiate(enemyShipPrefab);
                    newEnemy.transform.position = new Vector3(Random.Range(-5.5f, 5.5f), 0, 16);
                    EnemyCount--;
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else if (AstCount > 0)
            {
                for (int i = 0; i < AstCount; i++)
                {
                    int index = Random.Range(0, astroidPrefab.Length);
                    AsteroidMovement newAst = Instantiate(astroidPrefab[index]);
                    newAst.transform.position = new Vector3(Random.Range(-5.5f, 5.5f), 0, 16);
                    yield return new WaitForSeconds(0.5f);
                }
                AstCount = 0;
            }
            else if (EnemyCount > 0)
            {
                for (int i = 0; i < EnemyCount; i++)
                {
                    EnemyController newEnemy = Instantiate(enemyShipPrefab);
                    newEnemy.transform.position = new Vector3(Random.Range(-5.5f, 5.5f), 0, 16);
                    yield return new WaitForSeconds(0.5f);
                }
                EnemyCount = 0;
            }
            else
            {
                AstCount = 10;
                EnemyCount = 5;
                yield return new WaitForSeconds(SpawnRate);
            }

            
        }
    }

	// Update is called once per frame
	void Update () {
    }
}
