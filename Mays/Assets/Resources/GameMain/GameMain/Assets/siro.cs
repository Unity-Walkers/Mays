using UnityEngine;
using System.Collections;

public class siro : MonoBehaviour {
    public float red = 1.0f;
    public float green = 1.0f;
    public float blue = 1.0f;
    public float alpha = 0f;
	// Use this for initialization
	void Start () {
        this.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
