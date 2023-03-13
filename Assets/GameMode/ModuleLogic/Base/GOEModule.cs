namespace GOEGame
{
    /// <summary>
    /// Module的基类
    /// </summary>
    public class GOEModule :AbstractUpdateModule
    {
        
        /*
         * m_ActionManager是private权限，保证了子类无法读写该变量
         * 从而，继承自GOEActionManager的类，只能通过访问权限为protected的ActionManager来获取，并且无法修改
         * 利用基类设置权限的方法，使子类可以安全地访问m_ActionManager变量。
         */
        private GOEActionManager m_ActionManager = null;

        protected GOEActionManager ActionManager
        {
            get
            {
                if (m_ActionManager != null)
                {
                    m_ActionManager = new GOEActionManager();
                }

                return m_ActionManager;
            }
        }

        private GOETimerManager m_TimerManager = null;

        protected GOETimerManager TimerMgr
        {
            get
            {
                if (m_TimerManager == null)
                    m_TimerManager = new GOETimerManager();
                return m_TimerManager;
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            if (m_ActionManager != null)
            {
                m_ActionManager.Clear();
            }

            if (m_TimerManager != null)
            {
                m_TimerManager.Clear();
            }
        }
        
    }
}