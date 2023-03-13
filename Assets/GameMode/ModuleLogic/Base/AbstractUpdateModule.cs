using System.Linq.Expressions;

namespace GOEGame
{
    /*
     *功能描述：支持执行Update的Module基类
     * 
     */
    
    public class AbstractUpdateModule:IModule,IUpdate
    {
        private bool _enable = false;
        public AbstractUpdateModule()
        {
            
        }
        public virtual void Start() { }
        public virtual void Update(float deltaTime) { }
        public virtual void LateUpdate() { }
        
        /// <summary>
        /// 退出游戏前执行此方法，用于清理非托管资源
        /// </summary>
        public virtual void Dispose() { }


        public virtual bool Enable
        {
            get
            {
                return _enable;
            }
            protected set
            {
                if(_enable!=value)
                    SetEnable(value);
            }
            
        }

        protected virtual void SetEnable(bool value)
        {
            _enable = value;
        }

        /// <summary>
        /// 退出游戏时执行此方法，用于清理数据
        /// </summary>
        public virtual void ClearData()
        {
            
        }

        public virtual bool NeedUpdate()
        {
            return false;
        }
    }
}