using UnityEngine;
using System.Collections;

public class stage : MonoBehaviour {


    float X;
    float Y;
    float Z;

    private Vector3 acceleration;
    /// <summary>フォント</summary>
    private GUIStyle labelStyle;
	// Use this for initialization
	void Start () 
    {

     }
	
	// Update is called once per frame
	void Update () {
        //文字描画はOnGUIでしかできないらしいので保持
        this.acceleration = Input.acceleration;

	}
    void OnGUI()
    {
        if (acceleration != null)
        {
            float x = Screen.width / 10;
            float y = 0;
            float w = Screen.width * 8 / 10;
            float h = Screen.height / 20;
          

            for (int i = 0; i < 3; i++)
            {
                y = Screen.height / 10 + h * i;
                string text = string.Empty;

                switch (i)
                {
                    case 0://X
                        text = string.Format("accel-X:{0}", System.Math.Round(this.acceleration.x, 3));
                        break;
                    case 1://Y
                        text = string.Format("accel-Y:{0}", System.Math.Round(this.acceleration.y, 3));
                        break;
                    case 2://Z
                        text = string.Format("accel-Z:{0}", System.Math.Round(this.acceleration.z, 3));
                        break;
                    default:
                        throw new System.InvalidOperationException();
                }


            }
        }

       
    }

   
}
