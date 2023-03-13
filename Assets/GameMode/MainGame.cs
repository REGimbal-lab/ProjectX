using System.Collections;
using System.Collections.Generic;
using GOEGame;
using UnityEngine;


/// <summary>
/// 游戏入口类
/// </summary>
public class MainGame : MonoBehaviour
{

    private AppMain m_App;
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_App = new AppMain();
        
        
        m_App.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_App != null)
        {
            m_App.Update();
        }
    }
}
