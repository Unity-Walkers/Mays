using UnityEngine;
using System.Collections;

public class startBotan : MonoBehaviour
{

    public float timer = 0;
    public int time = 0;
    public float alphaS = 0.0f;
    public float alphaW = 0.0f;
    public bool flag;

    GameObject TitleW;
    GameObject TitleS;
    //Start_Button

    // Use this for initialization
    void Start()
    {
        flag = false;
        TitleW = GameObject.FindWithTag("Title_White");
        TitleW.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaW);

        TitleS = GameObject.FindWithTag("Start_Button");
        TitleS.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaS);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + 1;

        if ((time > 40) && (time < 55))
        {
            if (alphaS <= 1.0f)
            {
                alphaS = alphaS + 0.1f;
                // 元の画像の色のまま、半透明になって表示される。
                TitleS.GetComponent<SpriteRenderer>().color = new Color(1,1,1, alphaS);
            }

        }

        if (flag)
        {
            timer += Time.deltaTime;
            alphaW = alphaW + 0.03f;
            TitleW.GetComponent<SpriteRenderer>().color = new Color(1,1,1, alphaW);
        }

        if (timer > 2)
        {
            Application.LoadLevel("select");
        }

        if (time > 55)
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
                    flag = true;
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
                        flag = true;
                    }
                }
            }
        }
    }
}
