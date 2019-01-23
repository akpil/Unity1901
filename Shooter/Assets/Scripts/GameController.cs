using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public AsteroidMovement[] astroidPrefab;
    public EnemyController enemyShipPrefab;
    public PlayerController player;
    public BossController bossPrefab;

    public UIController uiController;

    public BGScroller bg1;
    public BGScroller bg2;

    private int Score;

    public float SpawnRate;
    public int BossSpawnCount;
    private int currentBossSpwanCount;
    private bool isBossPhase;

    private Coroutine enemy;
    private bool isGameOver;

    // Use this for initialization
    void Start () {
        enemy = StartCoroutine(SpawnEnemy());
        Score = 0;
        isGameOver = false;

        currentBossSpwanCount = 0;
        isBossPhase = false;
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
        StartCoroutine(GameOverRoutine());
    }

    private IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(6);
        //game  over 알려주기
        uiController.ShowGameOver();
        //다시시작 활성화 하기
        isGameOver = true;
    }

    public void ReStart()
    {
        SceneManager.LoadScene(1);
        //enemy = StartCoroutine(SpawnEnemy());
        //bg1.StartMove();
        //bg2.StartMove();
        //Score = 0;
        //uiController.ShowScore(Score);
        //uiController.HideGameOver();
        //Instantiate(player);
        //isGameOver = false;
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
                currentBossSpwanCount++;
                AstCount = 10;
                EnemyCount = 5;
                yield return new WaitForSeconds(SpawnRate);
                if (currentBossSpwanCount >= BossSpawnCount)
                {
                    currentBossSpwanCount = 0;
                    isBossPhase = true;
                    Instantiate(bossPrefab);
                    while (isBossPhase)
                    {
                        yield return new WaitForSeconds(0.5f);
                    }
                    yield return new WaitForSeconds(SpawnRate);
                }
                else
                {
                    continue;
                }
            }
        }
    }

    public void BossDead()
    {
        Score += 1000;
        uiController.ShowScore(Score);
        isBossPhase = false;
    }

	// Update is called once per frame
	void Update () {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            ReStart();
        }
    }
}
