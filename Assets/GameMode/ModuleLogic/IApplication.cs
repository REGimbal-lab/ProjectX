namespace GOEGame
{
    public interface IApplication
    {
        /// <summary>
        /// 每帧调用
        /// </summary>
        void Update();
        
        /// <summary>
        /// 比Start()更早调用
        /// </summary>
        void Awake();
        
        /// <summary>
        /// 游戏开始时调用，先于第一帧执行
        /// </summary>
        void Start();

        /// <summary>
        /// 每帧执行，但是比Update稍晚
        /// </summary>
        void LateUpdate();
    }
}