using UnityEngine;
using System.Collections;

public class select1 : MonoBehaviour {

    public int time;
    public int select;
    public bool flag;
	void Start () {
        time = 0;
        select = 0;
        flag = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(flag)
        {
            time = time + 1;
        }

        if (time == 40)
        {
            if(select ==1)
            {
                Application.LoadLevel("test1");
            }
            if (select == 2)
            {
                Application.LoadLevel("test2");
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
