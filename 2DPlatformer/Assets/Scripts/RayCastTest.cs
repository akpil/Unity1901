using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void cast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 3);
        Debug.Log(hit.collider.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            cast();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 far = Camera.main.ScreenToWorldPoint(
                        new Vector3(Input.mousePosition.x,
                                    Input.mousePosition.y,
                                    Camera.main.farClipPlane)
                      );
            Vector3 near = Camera.main.ScreenToWorldPoint(
                            new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Camera.main.nearClipPlane)
                          );
            Vector3 dir = far - near;

            Ray ray = new Ray(near, dir);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log(hit.point);
                    GameObject eff = Instantiate(effect);
                    eff.transform.position = hit.point;
                }
            }
        }
        

    }
}
