using UnityEngine;
using System.Collections;

public class select1 : MonoBehaviour {

    public float red = 1.0f;
    public float green = 1.0f;
    public float blue = 1.0f;
    public float alpha = 0.0f;

    public float timer = 0; 
    public float time;
    public int select;
    public bool flag;
    GameObject kabe;
    void Start()
    {
        time = 0;
        select = 0;
        flag = false;
        
        kabe = GameObject.FindWithTag("TagEnemy");
        kabe.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
    }
	
	// Update is called once per frame
	void Update () {
        if(flag)
        {
            timer += Time.deltaTime;
            time = time + 1;
            alpha = alpha + 0.03f;
            kabe.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
        }

        if (timer > 2)
        {
            if(select ==1)
            {
                Application.LoadLevel("GameMain");
            }
            if (select == 2)
            {
                Application.LoadLevel("test1");
            }
        }
        //マウスクリック
        if (this == Input.GetMouseButtonUp(0))
        {
            Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

            if (aCollider2d && aCollider2d.gameObject.tag == "Tag 0")
            {
                GameObject obj = aCollider2d.transform.gameObject;
                Debug.Log(obj.name);
                flag = true;
                select = 1;
                //Application.LoadLevel("test1");
            }
            if (aCollider2d && aCollider2d.gameObject.tag == "Tag 1")
            {
                GameObject obj = aCollider2d.transform.gameObject;
                Debug.Log(obj.name);
                flag = true;
                select = 2;
                //Application.LoadLevel("test2");
            }

        }
        //タッチ操作
        foreach (Touch inputTouch in Input.touches)
        {
            if (inputTouch.phase == TouchPhase.Began)
            {
                Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

                if (aCollider2d && aCollider2d.gameObject.tag == "Tag 0")
                {
                    GameObject obj = aCollider2d.transform.gameObject;
                    Debug.Log(obj.name);
                    flag = true;
                    select = 1;
                    //Application.LoadLevel("test1");
                }
                if (aCollider2d && aCollider2d.gameObject.tag == "Tag 1")
                {
                    GameObject obj = aCollider2d.transform.gameObject;
                    Debug.Log(obj.name);
                    flag = true;
                    select = 2;
                    //Application.LoadLevel("test2");
                }
            }
        }
	}
}
