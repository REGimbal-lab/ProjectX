using System;

namespace GOEGame.Facade
{
    public class Game
    {
        /// <summary>
        /// 所有模块加载完成，游戏启动成功
        /// </summary>
        public static Action GameStartup;

        /// <summary>
        /// 清除游戏本地数据（比如 断网 或者游戏内切换角色）
        /// </summary>
        public static Action QuiteGameClearData;

        /// <summary>
        /// 清除游戏本地数据，并返回到登录界面
        /// </summary>
        public static Action QuiteGameLogin;

        /// <summary>
        /// 失去焦点
        /// </summary>
        public static Action OnApplicationFocusLost;

        /// <summary>
        /// 重新获取焦点
        /// </summary>
        public static Action OnAppLicationResume;

        /// <summary>
        /// 下一帧执行操作
        /// </summary>
        public static Action NextFrameExecute;
    }
}