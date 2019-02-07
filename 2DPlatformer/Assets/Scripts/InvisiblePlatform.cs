using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour {

    public GameObject image;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            image.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        image.SetActive(false);

    }
}
