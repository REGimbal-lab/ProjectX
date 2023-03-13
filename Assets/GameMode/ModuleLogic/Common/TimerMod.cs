using System;
using System.Collections.Generic;

namespace GOEGame
{
    /*
     *  定时器模块类
     */
    public class TimerMod : AbstractUpdateModule
    {
        public static bool pause { get; set; }
        private static List<TimeFunc> _funs = new List<TimeFunc>();
        private static TimerMod _instance = new TimerMod();
        
        internal static List<TimeFunc> functoins
        {
            get { return _funs; }
        }

        public static TimerMod Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 将函数添加到_funs变量中
        /// 若传入的time值为0，则执行一遍传入的fun函数后返回
        /// 若非零，则根据fun，time新建一个TimeFunc类，并将其添加到_funs中
        /// </summary>
        /// <param name="fun">要添加的函数指针</param>
        /// <param name="time">周期 fun方法周期执行的周期</param>
        /// <param name="loop">fun方法能否循环，默认为false</param>
        /// <param name="canPause">fun方法能否被暂停，默认为true</param>
        public static void SetTimeOut(Action fun, float time, bool loop = false, bool canPause = true)
        {
            if (time > 0)
            {
                if (checkDuplicate(fun))
                    return;
                TimeFunc tf = new TimeFunc(fun, time);
                tf.loop = loop;
                tf.canPause = canPause;
                _funs.Add(tf);
                _instance.Enable = true;
            }
            else
            {
                fun();
            }
        }

        /// <summary>
        /// 调用SetTimeOut方法
        /// 传入SetTimeOut的loop值为true，因为周期执行当然是循环的
        /// </summary>
        /// <param name="fun">传入SetTimeOut的函数指针</param>
        /// <param name="interval">fun的执行周期</param>
        /// <param name="canPause">fun能否被暂停</param>
        public static void SetTimeInterval(Action fun, float interval, bool canPause = true)
        {
            if (interval > 0)
            {
                SetTimeOut(fun,interval,true,canPause);
            }
        }

        /// <summary>
        /// 移除_funs中的特定方法，以结束该函数的周期执行
        /// </summary>
        /// <param name="fun">要移除的方法</param>
        public static void RemoveTimeAction(Action fun)
        {
            int len = _funs.Count;
            for (int i = 0; i < len; i++)
            {
                if (_funs[i].handler == fun)
                {
                    _funs.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// 清空_funs
        /// </summary>
        public static void ClearAllAction()
        {
            _funs.Clear();
        }

        public override bool NeedUpdate()
        {
            return true;
        }

        /// <summary>
        /// 每帧执行
        /// </summary>
        /// <param name="deltaTime">游戏执行每帧需要花费的时间</param>
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            int len = _funs.Count;
            for (int i = 0; i < len; i++)
            {
                if(_funs[i].canPause && pause)
                    continue;
                if (UnityEngine.Time.time >= _funs[i].time)
                {
                    Facade.Game.NextFrameExecute += _funs[i].handler;
                    if (_funs[i].loop)
                    {
                        _funs[i].Reset();
                    }
                    else
                    {
                        _funs.RemoveAt(i);
                        i--;
                        len--;
                    }
                }
            }

            if (_funs.Count == 0)
            {
                Enable = false;
            }
        }

        /// <summary>
        /// 清理方法
        /// </summary>
        public override void Dispose()
        {
            ClearAllAction();
            
            base.Dispose();
        }


        /// <summary>
        /// 检查是否有重复的Action
        /// </summary>
        /// <param name="fun">要检查的Action</param>
        /// <returns></returns>
        private static bool checkDuplicate(Action fun)
        {
            int len = _funs.Count;
            for (int i = 0; i < len; i++)
            {
                if (_funs[i].handler == fun)
                    return true;
            }

            return false;
        }


    }



    class TimeFunc
    {
        public Action handler;
        public float time;
        public float maxTime;
        public bool loop;
        public bool canPause;
        public float Interval = -1.0f;

        public TimeFunc(Action fun, float tm, bool loop = false, bool canPause = true)
        {
            handler = fun;
            Interval = tm;
            time = UnityEngine.Time.time;
            maxTime = time;
            this.loop = loop;
            this.canPause = canPause;
        }

        public void Reset()
        {
            time = UnityEngine.Time.time + Interval;
        }
    }
}