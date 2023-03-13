using System;
using UnityEngine;

namespace GOEGame
{
    public interface IGOEAction
    {
        void Dispose(object obj);
    }

    public class CacheAct
    {
        public Action action;
    }
    
    public class CacheAct<T1>
    {
        public Action<T1> action;
    }
    
    
    public class CacheAct<T1,T2>
    {
        public Action<T1,T2> action;
    }
    
    public class CacheAct<T1,T2,T3>
    {
        public Action<T1,T2,T3> action;
    }
    
    public class CacheAct<T1,T2,T3,T4>
    {
        public Action<T1,T2,T3,T4> action;
    }

    public class CacheFun<T1>
    {
        public Func<T1> func;
    }
    
    public class CacheFun<T1, T2>
    {
        public Func<T1, T2> func;
    }
    
    public class CacheFun<T1, T2, T3>
    {
        public Func<T1, T2, T3> func;
    }
    
    public class CacheFun<T1, T2, T3, T4>
    {
        public Func<T1, T2, T3, T4> func;
    }
    
    public class CacheFun<T1, T2, T3, T4, T5>
    {
        public Func<T1, T2, T3, T4, T5> func;
    }
    

    public class GOEAction : IGOEAction
    {
        private Action action;

        public void Invoke()
        {
            if(action!=null)
                action.Invoke();
        }
        
        
        public void Dispose(object obj)
        {
            CacheAct a=obj as CacheAct;
            if (a != null)
            {
                action -= a.action;
            }
        }

        public static GOEAction operator +(GOEAction a, Action b)
        {
            a.action -= b;
            a.action += b;
            return a;
        }
        
        public static GOEAction operator -(GOEAction a, Action b)
        {
            a.action -= b;
            return a;
        }
    }

    public class GOEAction<T1> : IGOEAction
    {
        private Action<T1> action;

        public void Invoke(T1 t)
        {
            if (action != null)
                action.Invoke(t);
        }


        public void Dispose(object obj)
        {
            CacheAct<T1> a = obj as CacheAct<T1>;
            if (a != null)
            {
                action -= a.action;
            }
        }

        public static GOEAction<T1> operator +(GOEAction<T1> a, Action<T1> b)
        {
            a.action -= b;
            a.action += b;
            return a;
        }

        public static GOEAction<T1> operator -(GOEAction<T1> a, Action<T1> b)
        {
            a.action -= b;
            return a;
        }
    }

    public class GOEAction<T1, T2> : IGOEAction
    {
        private Action<T1, T2> action;

        public void Invoke(T1 t1, T2 t2)
        {
            if (action != null)
                action.Invoke(t1, t2);
        }


        public void Dispose(object obj)
        {
            CacheAct<T1, T2> a = obj as CacheAct<T1, T2>;
            if (a != null)
            {
                action -= a.action;
            }
        }

        public static GOEAction<T1, T2> operator +(GOEAction<T1, T2> a, Action<T1, T2> b)
        {
            a.action -= b;
            a.action += b;
            return a;
        }

        public static GOEAction<T1, T2> operator -(GOEAction<T1, T2> a, Action<T1, T2> b)
        {
            a.action -= b;
            return a;
        }
    }

    public class GOEAction<T1, T2, T3> : IGOEAction
    {
        private Action<T1, T2, T3> action;

        public void Invoke(T1 t1, T2 t2, T3 t3)
        {
            if (action != null)
                action.Invoke(t1, t2, t3);
        }


        public void Dispose(object obj)
        {
            CacheAct<T1, T2, T3> a = obj as CacheAct<T1, T2, T3>;
            if (a != null)
            {
                action -= a.action;
            }
        }

        public static GOEAction<T1, T2, T3> operator +(GOEAction<T1, T2, T3> a, Action<T1, T2, T3> b)
        {
            a.action -= b;
            a.action += b;
            return a;
        }

        public static GOEAction<T1, T2, T3> operator -(GOEAction<T1, T2, T3> a, Action<T1, T2, T3> b)
        {
            a.action -= b;
            return a;
        }
    }

    public class GOEAction<T1,T2,T3,T4> : IGOEAction
    {
        private Action<T1, T2, T3, T4> action;

        public void Invoke(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            if (action != null)
                action.Invoke(t1, t2, t3, t4);
        }


        public void Dispose(object obj)
        {
            CacheAct<T1, T2, T3, T4> a = obj as CacheAct<T1, T2, T3, T4>;
            if (a != null)
            {
                action -= a.action;
            }
        }

        public static GOEAction<T1, T2, T3, T4> operator +(GOEAction<T1, T2, T3, T4> a, Action<T1, T2, T3, T4> b)
        {
            a.action -= b;
            a.action += b;
            return a;
        }

        public static GOEAction<T1, T2, T3, T4> operator -(GOEAction<T1, T2, T3, T4> a, Action<T1, T2, T3, T4> b)
        {
            a.action -= b;
            return a;
        }
    }
    
    public class GOEFunction<T1> : IGOEAction
    {
        private Func<T1> func;

        public T1 Invoke()
        {
            return func != null ? func.Invoke() : default(T1);
        }


        public void Dispose(object obj)
        {
            CacheFun<T1> a = obj as CacheFun<T1>;
            if (a != null)
            {
                func -= a.func;
            }
        }

        public static GOEFunction<T1> operator +(GOEFunction<T1> a, Func<T1> b)
        {
            a.func -= b;
            a.func += b;
            return a;
        }

        public static GOEFunction<T1> operator -(GOEFunction<T1> a, Func<T1> b)
        {
            a.func -= b;
            return a;
        }
    }
    
    public class GOEFunction<T1,T2> : IGOEAction
    {
        private Func<T1, T2> func;

        public T2 Invoke(T1 t1)
        {
            return func != null ? func.Invoke(t1) : default(T2);
        }


        public void Dispose(object obj)
        {
            CacheFun<T1, T2> a = obj as CacheFun<T1, T2>;
            if (a != null)
            {
                func -= a.func;
            }
        }

        public static GOEFunction<T1, T2> operator +(GOEFunction<T1, T2> a, Func<T1, T2> b)
        {
            a.func -= b;
            a.func += b;
            return a;
        }

        public static GOEFunction<T1, T2> operator -(GOEFunction<T1, T2> a, Func<T1, T2> b)
        {
            a.func -= b;
            return a;
        }
    }
    
    public class GOEFunction<T1,T2,T3> : IGOEAction
    {
        private Func<T1, T2, T3> func;

        public T3 Invoke(T1 t1, T2 t2)
        {
            return func != null ? func.Invoke(t1, t2) : default(T3);
        }


        public void Dispose(object obj)
        {
            CacheFun<T1, T2, T3> a = obj as CacheFun<T1, T2, T3>;
            if (a != null)
            {
                func -= a.func;
            }
        }

        public static GOEFunction<T1, T2, T3> operator +(GOEFunction<T1, T2, T3> a, Func<T1, T2, T3> b)
        {
            a.func -= b;
            a.func += b;
            return a;
        }

        public static GOEFunction<T1, T2, T3> operator -(GOEFunction<T1, T2, T3> a, Func<T1, T2, T3> b)
        {
            a.func -= b;
            return a;
        }
    }
    
    public class GOEFunction<T1,T2,T3,T4> : IGOEAction
    {
        private Func<T1,T2,T3,T4> func;

        public T4 Invoke(T1 t1, T2 t2, T3 t3)
        {
            return func != null ? func.Invoke(t1, t2, t3) : default(T4);
        }


        public void Dispose(object obj)
        {
            CacheFun<T1, T2, T3, T4> a = obj as CacheFun<T1, T2, T3, T4>;
            if (a != null)
            {
                func -= a.func;
            }
        }

        public static GOEFunction<T1, T2, T3, T4> operator +(GOEFunction<T1, T2, T3, T4> a, Func<T1, T2, T3, T4> b)
        {
            a.func -= b;
            a.func += b;
            return a;
        }

        public static GOEFunction<T1, T2, T3, T4> operator -(GOEFunction<T1, T2, T3, T4> a, Func<T1, T2, T3, T4> b)
        {
            a.func -= b;
            return a;
        }
    }
    
    public class GOEFunction<T1,T2,T3,T4,T5> : IGOEAction
    {
        private Func<T1,T2,T3,T4,T5> func;

        public T5 Invoke(T1 t1,T2 t2,T3 t3,T4 t4)
        {
            return func != null ? func.Invoke(t1,t2,t3,t4) : default(T5);
        }
        
        
        public void Dispose(object obj)
        {
            CacheFun<T1,T2,T3,T4,T5> a=obj as CacheFun<T1,T2,T3,T4,T5>;
            if (a != null)
            {
                func -= a.func;
            }
        }

        public static GOEFunction<T1, T2, T3, T4, T5> operator +(GOEFunction<T1, T2, T3, T4, T5> a,
            Func<T1, T2, T3, T4, T5> b)
        {
            a.func -= b;
            a.func += b;
            return a;
        }

        public static GOEFunction<T1, T2, T3, T4, T5> operator -(GOEFunction<T1, T2, T3, T4, T5> a,
            Func<T1, T2, T3, T4, T5> b)
        {
            a.func -= b;
            return a;
        }
    }
    
}