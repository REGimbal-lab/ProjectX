//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public abstract class GameBase
    {
        public abstract GameMode GameMode
        {
            get;
        }

        protected ScrollableBackground SceneBackground
        {
            get;
            private set;
        }

        public bool GameOver
        {
            get;
            protected set;
        }

        private List<GameGround> _GroundList = null;

        public List<GameGround> GroundList
        {
            get
            {                   
                return _GroundList;
            }
        }

        private MyAircraft m_MyAircraft = null;

        public GameBase()
        {
            _GroundList = new List<GameGround>();
        }

        public virtual void Initialize()
        {
            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);


            GameEntry.Entity.ShowPlayerDragon(new PlayerDragonData(GameEntry.Entity.GenerateSerialId(),80000)
            {
                Position = Vector3.zero,
            });
            for (int i = 0; i < 3; i++)
            {
                OnShowGameGround();
            }

            GameOver = false;
            m_MyAircraft = null;
        }

        public virtual void Shutdown()
        {
            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            GameEntry.Event.Unsubscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
            if (m_MyAircraft != null && m_MyAircraft.IsDead)
            {
                GameOver = true;
                return;
            }
        }

        protected virtual void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs ne = (ShowEntitySuccessEventArgs)e;
            if (ne.EntityLogicType == typeof(MyAircraft))
            {
                m_MyAircraft = (MyAircraft)ne.Entity.Logic;
            }

            if (ne.EntityLogicType == typeof(GameGround))
            {
                _GroundList.Add(ne.Entity.Logic as GameGround);
            }
        }

        protected virtual void OnShowEntityFailure(object sender, GameEventArgs e)
        {
            ShowEntityFailureEventArgs ne = (ShowEntityFailureEventArgs)e;
            Log.Warning("Show entity failure with error message '{0}'.", ne.ErrorMessage);
        }

        public virtual void OnShowGameGround()
        {
            GameEntry.Entity.ShowGameGround(new GameGroundData(GameEntry.Entity.GenerateSerialId(), 90000, CampType.Player)
            {
                Position = Vector3.zero,
                GroundContainer = _GroundList,
            });
        }
    }
}
