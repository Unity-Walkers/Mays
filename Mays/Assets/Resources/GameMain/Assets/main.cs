using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

    [SerializeField]
    GameObject ball;        // ボールのオブジェクト

    [SerializeField]
    GameObject goal;            // ゴールのオブジェクト


    

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	 void Update ()
    {
        Vector3 spherePos = ball.transform.position;        // ボールの位置
        Vector3 goalPos = goal.transform.position;            // ゴールの位置

        /* ここで距離を計算して、距離が一定以内ならゴールと判定する */
        float dis = Vector3.Distance(spherePos, goalPos);
       // Debug.Log("Distance : " + dis);
        Debug.Log(spherePos);
        if (dis<=3)
         {
             CameraFade.StartAlphaFade(Color.white, false, 1f, 0f, () => { Application.LoadLevel("GameResult"); });
           //  Application.LoadLevel("test");
         }
    }
}
