using UnityEngine;
using System.Collections;

public class title : MonoBehaviour {

    public float Yziku = 6.0f;
    public int time = 0; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time = time + 1;
        if(Yziku>=2.2f)
        {
            this.transform.localPosition = new Vector3(0.0f, Yziku, 0.0f);
            Yziku = Yziku - 0.1f;
        }
	}
}
