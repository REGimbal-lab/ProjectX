using System;
using System.Linq;
using GOEGame.Facade;
using Unity.VisualScripting;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public class GameGround:EntityLogic
    {
        private BoxCollider EndCollision = null;
        private GameObject NextSpawnPosition = null;
        private GameGroundData _gameGroundData = null;
        private GameObject Plane = null;
        


        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            _gameGroundData=userData as GameGroundData;
            
            
            EndCollision = GetComponentInChildren<BoxCollider>();
            Plane = transform.GetChild(0).gameObject;
            NextSpawnPosition = Plane.transform.Find("NextSpawnPosition").gameObject;
            
            
            if (_gameGroundData.GroundContainer != null && _gameGroundData.GroundContainer.Count != 0)
            {
                Vector3 _LastPosition = _gameGroundData.GroundContainer.Last().NextSpawnPosition.transform.position;
                transform.position = _LastPosition;
            }
            
            _gameGroundData.GroundContainer.Add(this);
        }


        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            
            //EndCollision.On
        }
        
        public void OnTrigerEnter(Collider collider)
        {
        
        }
    }
    
}