using System;
using System.Collections.Generic;

namespace GOEGame
{
    public class GOEActionManager
    {
        private Dictionary<object, object> m_Actions = new Dictionary<object, object>();
        
        public GOEAction RegAction(GOEAction goeAction,Action action)
        {
            if (goeAction == null)
            {
                goeAction = new GOEAction();
            }

            goeAction += action;
            m_Actions[goeAction] = new CacheAct { action = action };
            return goeAction;
        }
        
        public GOEAction<T1> RegAction<T1>(GOEAction<T1> goeAction,Action<T1> action)
        {
            if (goeAction == null)
            {
                goeAction = new GOEAction<T1>();
            }

            goeAction += action;
            m_Actions[goeAction] = new CacheAct<T1> { action = action };
            return goeAction;
        }
        
        public GOEAction<T1,T2> RegAction<T1,T2>(GOEAction<T1,T2> goeAction,Action<T1,T2> action)
        {
            if (goeAction == null)
            {
                goeAction = new GOEAction<T1,T2>();
            }

            goeAction += action;
            m_Actions[goeAction] = new CacheAct<T1,T2> { action = action };
            return goeAction;
        }
        
        public GOEAction<T1,T2,T3> RegAction<T1,T2,T3>(GOEAction<T1,T2,T3> goeAction,Action<T1,T2,T3> action)
        {
            if (goeAction == null)
            {
                goeAction = new GOEAction<T1,T2,T3>();
            }

            goeAction += action;
            m_Actions[goeAction] = new CacheAct<T1,T2,T3> { action = action };
            return goeAction;
        }
        
        public GOEAction<T1,T2,T3,T4> RegAction<T1,T2,T3,T4>(GOEAction<T1,T2,T3,T4> goeAction,Action<T1,T2,T3,T4> action)
        {
            if (goeAction == null)
            {
                goeAction = new GOEAction<T1,T2,T3,T4>();
            }

            goeAction += action;
            m_Actions[goeAction] = new CacheAct<T1,T2,T3,T4> { action = action };
            return goeAction;
        }

        public GOEFunction<T1> RegFunction<T1>(GOEFunction<T1> goeFunction, Func<T1> func)
        {
            if (goeFunction == null)
            {
                goeFunction = new GOEFunction<T1>();
            }

            goeFunction += func;
            m_Actions[goeFunction]=new CacheFun<T1> { func = func };
            return goeFunction;
        }
        
        public GOEFunction<T1,T2> RegFunction<T1,T2>(GOEFunction<T1,T2> goeFunction, Func<T1,T2> func)
        {
            if (goeFunction == null)
            {
                goeFunction = new GOEFunction<T1,T2>();
            }

            goeFunction += func;
            m_Actions[goeFunction]=new CacheFun<T1,T2> { func = func };
            return goeFunction;
        }
        
        public GOEFunction<T1,T2,T3> RegFunction<T1,T2,T3>(GOEFunction<T1,T2,T3> goeFunction, Func<T1,T2,T3> func)
        {
            if (goeFunction == null)
            {
                goeFunction = new GOEFunction<T1,T2,T3>();
            }

            goeFunction += func;
            m_Actions[goeFunction]=new CacheFun<T1,T2,T3> { func = func };
            return goeFunction;
        }
        
        public GOEFunction<T1,T2,T3,T4> RegFunction<T1,T2,T3,T4>(GOEFunction<T1,T2,T3,T4> goeFunction, Func<T1,T2,T3,T4> func)
        {
            if (goeFunction == null)
            {
                goeFunction = new GOEFunction<T1,T2,T3,T4>();
            }

            goeFunction += func;
            m_Actions[goeFunction]=new CacheFun<T1,T2,T3,T4> { func = func };
            return goeFunction;
        }
        
        public GOEFunction<T1,T2,T3,T4,T5> RegFunction<T1,T2,T3,T4,T5>(GOEFunction<T1,T2,T3,T4,T5> goeFunction, Func<T1,T2,T3,T4,T5> func)
        {
            if (goeFunction == null)
            {
                goeFunction = new GOEFunction<T1,T2,T3,T4,T5>();
            }

            goeFunction += func;
            m_Actions[goeFunction]=new CacheFun<T1,T2,T3,T4,T5> { func = func };
            return goeFunction;
        }

        public void Clear()
        {
            foreach (var item in m_Actions)
            {
                if (item.Key != null)
                {
                    ((IGOEAction)item.Key).Dispose(item.Value);
                }
            }
            m_Actions.Clear();
        }
    }
}