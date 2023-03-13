using System;
using UnityEngine;

namespace UnityGameFramework.Scripts.Runtime.EntityComponents
{
    public class VerticalMovementComponent:MonoBehaviour
    {
        private enum MoveType
        {
            Up,
            Down,
            Nope,
        }

        private MoveType m_MoveType = MoveType.Up;
        private float m_Speed = 0f;
        private float acceleration = 9.8f;
        private float maxSpeed = 8f;


        public void VerticalMove(Rigidbody rigidbody,GameObject obj)
        {
            rigidbody.AddForce(180*Vector3.up *acceleration * (rigidbody.mass)*Time.deltaTime);
        }
    }
}