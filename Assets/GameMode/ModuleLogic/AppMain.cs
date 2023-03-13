using System;
using System.Collections;
using System.Collections.Generic;
using GOEGame.Modules;
using UnityEngine;

namespace GOEGame
{
    public class AppMain:IApplication
    {

        private int m_LrameCount;
        private float m_LastFPS;
        private DateTime m_LastFrameTime;
        private float m_LastActiveTime;
        private float m_LastScreenBrightness;
        private int m_LastFrameRate;
        public void Start()
        {
            try
            {
                Facade.Game.QuiteGameLogin += OnQuiteLogin;

                ModuleMgr modMgr = ModuleMgr.Instance;
                
                modMgr.AddModule(new TestModule());
                
                modMgr.Start();
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
            }

        }

        public void Update()
        {
            ModuleMgr.Instance.Update(Time.deltaTime);
        }
        

        public void LateUpdate()
        {
            
        }

        public void Awake()
        {
            
        }

        private void OnQuiteLogin()
        {
            
        }
        
    }
}