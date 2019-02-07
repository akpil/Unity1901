using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float Speed;
    private Rigidbody2D rb2d;
    private Animator anim;

    public float MaxHP;
    private float currentHP;

    private Coroutine stateMachine;

    public int Score;
    private GameController controller;

    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHP = MaxHP;
        stateMachine = StartCoroutine(StateMachine());
        controller = GameObject.FindGameObjectWithTag("GameController").
                                        GetComponent<GameController>();
    }

    public void Move()
    {
        rb2d.velocity = transform.right * Speed;
        anim.SetFloat(AnimHash.Speed, Mathf.Abs(Speed));
    }

    public void Hit(float damage)
    {
        currentHP -= damage;
        // UI
        if(currentHP <= 0)
        {
            Dead();
        }
    }

    public void Stop()
    {
        rb2d.velocity = Vector2.zero;
        anim.SetFloat(AnimHash.Speed, 0);
        
    }

    public void StartAttack()
    {
        rb2d.velocity = Vector2.zero;
        anim.SetBool(AnimHash.Attack, true);
        
    }

    public void StopAttack()
    {
        anim.SetBool(AnimHash.Attack, false);
    }

    public void Dead()
    {
        rb2d.velocity = Vector2.zero;
        anim.SetBool(AnimHash.Dead, true);
        StopCoroutine(stateMachine);
        controller.AddScore(Score);
    }

    public void Rotate()
    {
        transform.Rotate(0, 180, 0);
    }

    public void ViewLeft()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public void ViewRight()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private IEnumerator StateMachine()
    {
        while (true)
        {
            Move();
            yield return new WaitForSeconds(1.5f);
            Stop();
            yield return new WaitForSeconds(0.5f);
            Move();
            yield return new WaitForSeconds(1.5f);
            Stop();
            if (Random.Range(0, 2) == 1)
            {
                Rotate();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Stop();
            Rotate();
            Move();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            StartAttack();
            collision.gameObject.SendMessage("Hit", 1);
        }
    }

    // Update is called once per frame
    void Update () {
	}
}
