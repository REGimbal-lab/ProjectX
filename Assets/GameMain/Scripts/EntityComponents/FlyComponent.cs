using UnityEngine;

namespace UnityGameFramework.Scripts.Runtime.EntityComponents
{
    public abstract class FlyComponent:MonoBehaviour
    {
        public abstract void Fly(float deltaTime);

    }
}