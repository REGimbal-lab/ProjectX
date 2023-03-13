using System.Collections.Generic;
using UnityEditor;

namespace GOEGame
{
    public class ModuleMgr : AbstractUpdateModule
    {
        private ModuleMgr()
        {

        }

        private static ModuleMgr m_Instance = null;

        private bool _isUpdating = false;
        private List<IModule> m_Adding = new List<IModule>();
        private List<IModule> m_Deling = new List<IModule>();

        private List<IModule> m_Mods = new List<IModule>();
        private List<IUpdate> m_UpdateMods = new List<IUpdate>();

        public static ModuleMgr Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ModuleMgr();
                }

                return m_Instance;
            }
        }


        public void AddModule(IModule mod)
        {
            if (_isUpdating)
            {
                m_Adding.Add(mod);
                return;
            }

            m_Mods.Add(mod);
            if (mod.NeedUpdate())
                m_UpdateMods.Add(mod as IUpdate);
        }

        public void RemoveModule(IModule mod)
        {
            if (_isUpdating)
            {
                m_Deling.Add(mod);
                return;
            }

            if (m_Mods.Contains(mod))
            {
                if (mod.NeedUpdate())
                {
                    m_UpdateMods.Remove(mod as IUpdate);
                }

                m_Mods.Remove(mod);
                mod.Dispose();
            }
        }

        public override void Start()
        {
            foreach (IModule mod in m_Mods)
            {
                mod.Start();
            }
        }

        public override void Update(float deltaTime)
        {
            _isUpdating = true;
            IUpdate updateModule;
            for (int i = 0; i < m_UpdateMods.Count; i++)
            {
                updateModule = m_UpdateMods[i];
                if (updateModule.Enable)
                {
                    UnityEngine.Profiling.Profiler.BeginSample(updateModule.GetType().ToString());
                    
                    updateModule.Update(deltaTime);
                    
                    UnityEngine.Profiling.Profiler.EndSample();
                }
            }

            _isUpdating = false;
            if (m_Adding.Count > 0)
            {
                foreach (var mod in m_Adding)
                {
                    AddModule(mod);
                }
                m_Adding.Clear();
            }

            if (m_Deling.Count > 0)
            {
                IModule mod = null;
                foreach (var m_Mod in m_Deling)
                {
                    mod = m_Mod;
                    RemoveModule(mod);
                }
                m_Deling.Clear();
            }
        }

        public override void LateUpdate()
        {
            _isUpdating = true;
            IUpdate updateModule;
            for (int i = 0; i < m_UpdateMods.Count; i++)
            {
                updateModule = m_UpdateMods[i];
                if (updateModule.Enable)
                {
                    updateModule.LateUpdate();
                }
            }

            _isUpdating = false;
            if (m_Adding.Count > 0)
            {
                foreach (var mod in m_Adding)
                {
                    AddModule(mod);
                }
                m_Adding.Clear();
            }

            if (m_Deling.Count > 0)
            {
                IModule mod = null;
                foreach (var m_Mod in m_Deling)
                {
                    mod = m_Mod;
                    RemoveModule(mod);
                }
                m_Deling.Clear();
            }
        }

        public override void Dispose()
        {
            ClearData();
            foreach (var mod in m_Mods)
            {
                mod.Dispose();
            }
            m_Mods.Clear();
        }

        public override void ClearData()
        {
            foreach (var mod in m_Mods)
            {
                mod.ClearData();
            }
        }

        public List<IModule> AllMods
        {
            get
            {
                return m_Mods;
            }
        }
    }
}