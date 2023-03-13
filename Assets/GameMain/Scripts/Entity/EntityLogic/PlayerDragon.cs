//#define TEST
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

namespace StarForce
{
    public class PlayerDragon : Dragon
    {
        private float g =  9.81f;
        private Rigidbody rigidbody = null;
        private CharacterController m_CharacterController = null;
        public float speed = 2.0f;
        private Transform mDragonModel = null;
        private Camera Camera = null;


        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            Camera = transform.Find("Camera").GetComponent<Camera>();
        }


#if TEST
        private void Start()
#else
        protected override void OnShow(object userData)
#endif
        {
#if !TEST
            base.OnShow(userData);
#endif
            mDragonModel = transform.Find("DragonModel");
            if (mDragonModel == null)
                return;
            rigidbody = mDragonModel.gameObject.GetComponent<Rigidbody>();
            m_CharacterController = gameObject.GetComponent<CharacterController>();
            if (m_CharacterController == null)
                m_CharacterController = gameObject.AddComponent<CharacterController>();
            m_CharacterController.center = new Vector3(0f, 0f, 0);
            m_CharacterController.radius = 0f;
            m_CharacterController.height = 0f;


            Camera.main.enabled = false;
            Camera.enabled = true;
        }

#if TEST
        private void Update()
#else
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#endif
        {
            if (rigidbody == null)
                return;

            m_CharacterController.Move(transform.forward * Time.deltaTime * speed);
            
            if (Input.GetMouseButton(0))
            {
                VerticalMovementComponent.VerticalMove(rigidbody,gameObject);
            }
        }
    }
}