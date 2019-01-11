using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public float xRot;
    public float yRot;
    public float zRot;
    private GameController controller;

	// Use this for initialization
	void Start () {
        GameObject cont = GameObject.FindGameObjectWithTag("GameController");
        controller = cont.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(xRot, yRot, zRot) * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            controller.AddScore();
            gameObject.SetActive(false);
        }
    }
}
