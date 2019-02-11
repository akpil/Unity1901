using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb2d;
    private Animator anim;
    public float MaxSpeed;
    public float Jump;
    public float Damage;
    public float MaxHP;
    private float currentHP;
    private bool onGround;
    private UIController uiCont;
    private GameController control;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHP = MaxHP;
        uiCont = GameObject.FindGameObjectWithTag("UI")
                .GetComponent<UIController>();
        control = GameObject.FindGameObjectWithTag("GameController")
                .GetComponent<GameController>();
    }

    public void Dead()
    {
        anim.SetBool(AnimHash.Dead, true);
        control.GameOver();
    }

	// Update is called once per frame
	void Update () {

        if (anim.GetBool(AnimHash.Dead))
        {
            return;
        }

        float horizontal;
        if (anim.GetBool(AnimHash.Attack))
        {
            horizontal = 0;
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal") * MaxSpeed;
        }
        rb2d.velocity = new Vector2(horizontal, rb2d.velocity.y);

        anim.SetFloat(AnimHash.Speed, Mathf.Abs(horizontal));

        if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool(AnimHash.Attack, true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool(AnimHash.Attack, false);
        }

        if (onGround && Input.GetButtonDown("Jump"))
        {
            anim.SetBool(AnimHash.Jump, true);
            rb2d.velocity = new Vector2(rb2d.velocity.x, Jump);
        }

        anim.SetFloat(AnimHash.VertSpeed, rb2d.velocity.y);
	}

    public void AttackTarget(GameObject target)
    {
        target.SendMessage("Hit", Damage);
    }

    public void Hit(float damage)
    {
        currentHP -= damage;
        uiCont.ShowPlayerHP(currentHP / MaxHP);
        if (currentHP <= 0)
        {
            anim.SetBool(AnimHash.Dead, true);
            control.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            anim.SetBool(AnimHash.Jump, false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
