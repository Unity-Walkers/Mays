using UnityEngine;
using System.Collections;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// 使用方法
    /// <Code>
    /// public void Awake()
    /// {
    ///     if(this != Instance)
    ///     {
    ///         Destroy(this);
    ///         return;
    ///     }
    ///     //引き継ぎたいゲームオブジェクトを宣言
    ///     DontDestroyOnLoad(this.gameObject);
    /// }
    /// </summary>

    private static T instance;
    public static T Instance
    {
        get
        {
            //インスタンスが無ければ
            if (instance == null)
            {
                //一番最初のアクティブなオブジェクトを返す
                instance = (T)FindObjectOfType(typeof(T));

                //インスタンスが無ければ
                if (instance == null)
                {
                    //デバッガにメッセージ表示
                    Debug.LogError(typeof(T) + "is nothing");
                }
            }
            return instance;
        }
    }

}
