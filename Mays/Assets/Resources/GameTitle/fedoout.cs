﻿using UnityEngine;
using System.Collections;

public class fedoout : MonoBehaviour {
    public float red = 1.0f;
    public float green = 1.0f;
    public float blue = 1.0f;
    public float alpha = 0.0f;
    public int time = 0;
    public bool a ;
	// Use this for initialization
	void Start () {
        this.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, 0);
        a = true;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (a)
        {
            time = time + 1;
        }
        if(time>20)
        {
            if (alpha < 1.0f)
            {
                alpha = alpha + 0.03f;
                // 元の画像の色のまま、半透明になって表示される。
                this.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
            }
            if (alpha >= 1.0f)
            {
                a = false;
                time = 0;
                Application.LoadLevel("select1");
            }
        }

	}
}
