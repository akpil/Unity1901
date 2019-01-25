using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Transform boltPosition;
    public Bolt[] boltPrefab;
    public float fireRate;
    private float currentFireRate;
    private int boltID;


    public GameObject effectPrefab;

    private Rigidbody rb;
    public float Speed;
    public float Tilt;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    public int MaxHP;
    private int currentHP;

    private SoundController sound;
    private GameController controller;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        currentFireRate = 0;
        boltID = 0;
        currentHP = MaxHP;
        GameObject soundObj = GameObject.FindGameObjectWithTag("SoundController");
        sound = soundObj.GetComponent<SoundController>();
        GameObject controlObj = GameObject.FindGameObjectWithTag("GameController");
        controller = controlObj.GetComponent<GameController>();
    }

    private void OnDestroy()
    {
        
        sound.PlayEffect(2);
        GameObject effect = Instantiate(effectPrefab);
        effect.transform.position = transform.position;
        controller.GameOver();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBolt"))
        {
            currentHP--;
            Debug.Log("current HP " + currentHP.ToString());
            controller.uiController.ShowPlayerHP(currentHP, MaxHP);
            if (currentHP <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("PowerUPItem"))
        {
            boltID = 1;
            fireRate -= 0.01f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("HPUPItem"))
        {
            if (currentHP < MaxHP)
            {
                currentHP++;
                if (currentHP > MaxHP)
                {
                    currentHP = MaxHP;
                }
            }
            

        }

    }

    // Update is called once per frame
    void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal, 0, vertical) * Speed;

        rb.rotation = Quaternion.Euler(new Vector3(0, 0, -horizontal * Tilt));

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax),
                                  0,
                                  Mathf.Clamp(rb.position.z, zMin, zMax));

        if (Input.GetButton("Fire1") && currentFireRate <= 0)
        {
            Bolt newBolt = Instantiate(boltPrefab[boltID]);
            newBolt.transform.position = boltPosition.position;
            sound.PlayEffect(4);
            currentFireRate = fireRate;
        }
        currentFireRate -= Time.deltaTime;
	}
}
