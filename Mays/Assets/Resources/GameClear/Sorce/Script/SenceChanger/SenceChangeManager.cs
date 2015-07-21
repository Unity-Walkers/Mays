using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SenceChangeManager : SingletonMonoBehaviour<SenceChangeManager>
{
    /// <summary>デバッグモード</summary>                        
    public bool DebugMode = false;
    /// <summary>フェード中かどうか</summary>
    private bool isFading = false;
    /// <summary>フェード中の透明度</summary>
    private float fadeAlpha = 0;
    /// <summary>フェード色</summary>
    public Color fadeColor = Color.black;
    /// <summary>シーン名</summary>
    public string Scene;
    /// <summary>変更時間</summary>
    public float ChangerTime = 0.0F;

    void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
        //引き継ぎたいゲームオブジェクトを宣言
        DontDestroyOnLoad(this);
    }

    public void OnClick()
    {
        this.LoadLevel(Scene, ChangerTime);
    }

    public void OnGUI()
    {

        // Fade .
        if (this.isFading)
        {
            //色と透明度を更新して白テクスチャを描画 .
            this.fadeColor.a = this.fadeAlpha;
            GUI.color = this.fadeColor;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
        }

        if (this.DebugMode)
        {
            if (!this.isFading)
            {
                //Scene一覧を作成 .
                //(UnityEditor名前空間を使わないと自動取得できなかったので決めうちで作成) .
                List<string> scenes = new List<string>();
                scenes.Add(Scene);

                //Sceneが一つもない .
                if (scenes.Count == 0)
                {
                    GUI.Box(new Rect(10, 10, 200, 50), "Fade Manager(Debug Mode)");
                    GUI.Label(new Rect(20, 35, 180, 20), "Scene not found.");
                    return;
                }


                GUI.Box(new Rect(10, 10, 300, 50 + scenes.Count * 25), "Fade Manager(Debug Mode)");
                GUI.Label(new Rect(20, 30, 280, 20), "Current Scene : " + Application.loadedLevelName);

                int i = 0;
                foreach (string sceneName in scenes)
                {
                    if (GUI.Button(new Rect(20, 55 + i * 25, 100, 20), "Load Level"))
                    {
                        LoadLevel(sceneName, ChangerTime);
                    }
                    GUI.Label(new Rect(125, 55 + i * 25, 1000, 20), sceneName);
                    i++;
                }
            }
        }
    }
    /// <summary>
    /// 画面遷移 .
    /// </summary>
    /// <param name='scene'>シーン名</param>
    /// <param name='interval'>暗転にかかる時間(秒)</param>
    public void LoadLevel(string scene, float interval)
    {
        StartCoroutine(TransScene(scene, interval));
    }

    /// <summary>
    /// シーン遷移用コルーチン .
    /// </summary>
    /// <param name='scene'>シーン名</param>
    /// <param name='interval'>暗転にかかる時間(秒)</param>
    private IEnumerator TransScene(string scene, float interval)
    {
        //だんだん暗く .
        this.isFading = true;
        float time = 0;
        while (time <= interval)
        {
            this.fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        //引き継ぎたいゲームオブジェクトを宣言
        DontDestroyOnLoad(this);

        //シーン切替 .
        Application.LoadLevel(scene);

        //だんだん明るく .
        time = 0;
        while (time <= (interval / 3))
        {
            this.fadeAlpha = Mathf.Lerp(1f, 0f, time / (interval / 3));
            time += Time.deltaTime;
            yield return 0;
        }

        this.isFading = false;
    }
}