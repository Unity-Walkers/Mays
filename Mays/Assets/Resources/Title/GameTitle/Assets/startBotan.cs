using UnityEngine;
using System.Collections;

public class startBotan : MonoBehaviour
{

    public int time = 0;
    public float red = 1.0f;
    public float green = 1.0f;
    public float blue = 1.0f;
    public float alpha = 0.0f;
    public bool a;

    // Use this for initialization
    void Start()
    {
        a = false;
    }

    // Update is called once per frame
    void Update() {
        if(time == 0)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
        }
        time = time + 1;
        
        if((time>40)&&(time <55))
        {
            if(alpha<=1.0f)
            {
                alpha = alpha + 0.1f;
                // 元の画像の色のまま、半透明になって表示される。
                this.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
            }

        }
        if(time>55)
        {
            //マウスクリック
            if (this == Input.GetMouseButtonUp(0))
            {
                Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

                if (aCollider2d)
                {
                    GameObject obj = aCollider2d.transform.gameObject;
                    Debug.Log(obj.name);
                    Application.LoadLevel("title2");
                }
            }
            //タッチ操作
            foreach (Touch inputTouch in Input.touches)
            {
                if (inputTouch.phase == TouchPhase.Began)
                {
                    Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

                    if (aCollider2d)
                    {
                        GameObject obj = aCollider2d.transform.gameObject;
                        Debug.Log(obj.name);
                        Application.LoadLevel("title2");
                    }
                }
            }
        }

	
	}
}
