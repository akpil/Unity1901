using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTextureScroll : MonoBehaviour {

    private Renderer rand;
    private Material mat;
    public float scrollSpeed;
    // Use this for initialization
    void Start () {
        rand = GetComponent<Renderer>();
        mat = rand.material;
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * scrollSpeed;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
        //mat.mainTextureOffset += new Vector2(0, scrollSpeed) * Time.deltaTime;

    }
}
