using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour {

    public float speed = 0.1f;
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.Repeat(Time.time * speed, 1);

        Vector2 offest = new Vector2(x, 0);

        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offest);
	}
}
