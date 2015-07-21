using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameClearEvent : MonoBehaviour
{
    private Canvas _canvas;
    private List<RawImage> image;

    void Start()
    {
        //Canvas取得
        _canvas = GameObject.Find("Main Canvas").GetComponent<Canvas>();
        
        //RawImage用リスト作成
        image = new List<RawImage>();
        foreach (Transform child in _canvas.transform)
        {
            //nullが取得される可能性があるためifを追加
            if (child.transform.gameObject.GetComponent<RawImage>() != null)
            {
                //CanvasからRawImageを取得
                image.Add(child.transform.gameObject.GetComponent<RawImage>());
            }
        }
    }

    void Updata()
    {

    }

    public void OnClick()
    {
        foreach(RawImage i in image)
        {
            if( i.name == "GameClearImage")
            {
                i.enabled = false;
            }
            else
            {
                i.enabled = true;
            }
        }
    }
}

