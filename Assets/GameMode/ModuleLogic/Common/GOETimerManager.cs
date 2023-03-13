using System;
using System.Collections.Generic;
using UnityEngine;

namespace GOEGame
{
    /// <summary>
    /// 时间管理类
    /// 管理的对象只有TimerMod的单例
    /// </summary>
    public class GOETimerManager
    {
        private int m_ID;
        private Dictionary<int, Action> m_Actions = new Dictionary<int, Action>();
        private Dictionary<Action, int> m_DictForID = new Dictionary<Action, int>();
        private Dictionary<Action, Action> m_NextFrames = new Dictionary<Action, Action>();
        private bool m_NextFrameFlag = false;

        private void AddAction(Action callBack, out Action fun, out int index)
        {
            int id = m_ID++;
            fun= delegate
            {
                callBack();
                m_Actions.Remove(id);
                m_DictForID.Remove(callBack);
            };
            m_Actions[id] = fun;
            m_DictForID[callBack] = id;
            index = id;
        }

        public int SetTimeOut(Action fun, float time, bool loop = false, bool canPause = true)
        {
            Action action = null;
            int index = 0;
            AddAction(fun,out action,out index);
            TimerMod.SetTimeOut(action,time,loop,canPause);
            return index;
        }

        /// <summary>
        /// 设置周期执行方法
        /// </summary>
        /// <param name="fun">需要周期执行的方法</param>
        /// <param name="interval">执行的周期</param>
        /// <param name="canPause">能否被暂停</param>
        /// <returns></returns>
        public int SetTimeInterval(Action fun, float interval, bool canPause = true)
        {
            Action action = null;
            int index = 0;
            AddAction(fun,out action,out index);
            TimerMod.SetTimeInterval(action,interval,canPause);
            return index;
        }

        public void NextFrameExecute(Action fun, int frame = 1)
        {
            if (frame > 0)
            {
                if (frame == 1)
                {
                    Action action= delegate
                    {
                        fun();
                        m_NextFrames.Remove(fun);
                    };
                    m_NextFrames.Add(fun,action);
                }
                else
                {
                    m_NextFrameFlag = true;
                }
            }
        }

        public bool RemoveTimeAction(Action fun)
        {
            int index = -1;
            if (m_DictForID.TryGetValue(fun, out index))
            {
                m_DictForID.Remove(fun);
                Action act = null;
                if (m_Actions.TryGetValue(index, out act))
                {
                    TimerMod.RemoveTimeAction(act);
                    m_Actions.Remove(index);
                    return true;
                }
            }

            return false;
        }

        public bool RemoveTimerAction(int index)
        {
            if (index >= 0)
            {
                Action act = null;
                if (m_Actions.TryGetValue(index, out act))
                {
                    TimerMod.RemoveTimeAction(act);
                    m_Actions.Remove(index);
                    m_DictForID.Remove(act);
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            foreach (var item in m_Actions)
            {
                TimerMod.RemoveTimeAction(item.Value);
            }

            foreach (var item in m_NextFrames)
            {
                
            }

            m_NextFrameFlag = false;
            m_Actions.Clear();
            m_DictForID.Clear();
            m_NextFrames.Clear();
        }
        
        
    }
}