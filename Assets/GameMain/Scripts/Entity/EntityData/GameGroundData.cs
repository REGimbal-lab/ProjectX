using System.Collections.Generic;
using UnityEngine;

namespace StarForce
{
    public class GameGroundData:TargetableObjectData
    {
        private int _MaxHP = 500;

        private List<GameGround> _groundContainer = null;

        public List<GameGround> GroundContainer
        {
            get
            {
                return _groundContainer;
            }
            set
            {
                _groundContainer = value;
            }
        }


        public GameGroundData(int entityId, int typeId, CampType camp):base(entityId,typeId,camp)
        {
            
        }
        
        

        public override int MaxHP
        {
            get
            {
                return _MaxHP;
            }
        }
    }
}