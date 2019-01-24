using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public Bolt bossBoltPrefab;
    public Transform boltPosition;
    private Coroutine fireRoutine;

    public GameObject effectPrefab;
    private SoundController sound;
    private GameController controller;
    private Rigidbody rb;

    private bool StartAttack;

    private UIController ui;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MovePhase());
        currentHP = MaxHP;
        GameObject soundObj = GameObject.FindGameObjectWithTag("SoundController");
        sound = soundObj.GetComponent<SoundController>();
        GameObject controlObj = GameObject.FindGameObjectWithTag("GameController");
        controller = controlObj.GetComponent<GameController>();
        ui = controller.uiController;

        ui.ShowHP(1);
        ui.ShowHPBar();
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            Bolt newBolt = Instantiate(bossBoltPrefab);
            newBolt.transform.position = boltPosition.position;
            sound.PlayEffect(3);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator MovePhase()
    {
        StartAttack = false;
        rb.velocity = transform.forward * 2;
        while (transform.position.z > 10)
        {
            yield return new WaitForSeconds(0.1f);
        }
        rb.velocity = Vector3.zero;
        StartAttack = true;

        fireRoutine = StartCoroutine(Fire());
        rb.velocity = transform.right * 2;
        while (true)
        {
            yield return new WaitForSeconds(2f);
            rb.velocity = Vector3.zero;
            StopCoroutine(fireRoutine);

            yield return new WaitForSeconds(0.5f);

            fireRoutine = StartCoroutine(Fire());
            rb.velocity = transform.right * -2;
            yield return new WaitForSeconds(4f);
            rb.velocity = Vector3.zero;
            StopCoroutine(fireRoutine);

            yield return new WaitForSeconds(0.5f);

            fireRoutine = StartCoroutine(Fire());
            rb.velocity = transform.right * 2;
            yield return new WaitForSeconds(2f);
        }
    }

    public int MaxHP;
    private int currentHP;

    private void OnTriggerEnter(Collider other)
    {
        if (StartAttack && other.gameObject.CompareTag("PlayerBolt"))
        {
            // 체력감소
            currentHP--;
            ui.ShowHP((float)currentHP/MaxHP);
            Debug.Log(currentHP);
            if (currentHP <= 0)
            {
                GameObject effect = Instantiate(effectPrefab);
                effect.transform.position = transform.position;
                sound.PlayEffect(1);
                Destroy(gameObject);
                ui.HideHPBar();
                
                controller.BossDead();
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
