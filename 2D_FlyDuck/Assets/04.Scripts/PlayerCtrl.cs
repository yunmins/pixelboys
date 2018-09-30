using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 300;

    float x;  //좌우
    float y;  //상하

    public Transform tr;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.gravityScale = 0;
        }
        else
            rb.gravityScale = 10;

        Vector2 dir = new Vector2(x, y);
        rb.velocity = dir * speed * Time.deltaTime; //가속도 작업

        // 화면 밖으로 나가지 못하게
        float size = Camera.main.orthographicSize;
        float offset = 0.3f;

        if (tr.position.y >= size - offset)
        {
            tr.position = new Vector3(tr.position.x, size - offset, 0);
        }

        if (tr.position.y <= -size + offset)  // 아래쪽 막힘
        {
            tr.position = new Vector3(tr.position.x, -size + offset, 0);
        }

        float screenRation = (float)Screen.width / (float)Screen.height;
        float wSize = Camera.main.orthographicSize * screenRation;

        if (tr.position.x >= wSize - offset)
        {
            tr.position = new Vector3(wSize - offset, tr.position.y, 0);
        }

        if (tr.position.x <= -wSize + offset)
        {
            tr.position = new Vector3(-wSize + offset, tr.position.y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        //부딪힌 객체의 태그를 비교해서 적인지 판단합니다.
        {

            Destroy(this.gameObject);
            //자신을 파괴합니다.
        }
    }
}
