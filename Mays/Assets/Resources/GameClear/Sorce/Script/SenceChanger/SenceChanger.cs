using UnityEngine;
using System.Collections;

public class SenceChanger : MonoBehaviour
{

    private SenceChangeManager m_SceneManager;
    public string SceneName;
    public float Interval;
    public Color Color;

    private bool flag = true;

    void Awake()
    {
        flag = true;
    }
    public void OnClick()
    {
        if (flag == true)
        {
            m_SceneManager = SenceChangeManager.Instance;
            m_SceneManager.fadeColor = Color;
            m_SceneManager.LoadLevel(SceneName, Interval);
            flag = false;
        }
    }
}