using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController controller = GameObject.FindGameObjectWithTag("GameController").
                                    GetComponent<GameController>();
            controller.GameFinish();
        }
    }

}
