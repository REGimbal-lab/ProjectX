using System;
using UnityEngine;

namespace UnityGameFramework.Scripts.Runtime.EntityComponents
{
    public class BoxCollider:MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("过来了");
        }
    }
}