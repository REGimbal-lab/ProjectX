//#define TEST
using UnityGameFramework.Scripts.Runtime.EntityComponents;

namespace StarForce
{
    public abstract class Dragon : TargetableObject
    {

        private DragonData m_DragonData = null;

        private FlyComponent m_FlyComponent = null;

        private VerticalMovementComponent m_VerticalMovementComponent;

        public VerticalMovementComponent VerticalMovementComponent
        {
            get
            {
                return m_VerticalMovementComponent;
            }
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
            m_VerticalMovementComponent = gameObject.AddComponent<VerticalMovementComponent>();
        }
        
        
        
        
        
        public override ImpactData GetImpactData()
        {
            return new ImpactData(m_DragonData.Camp, m_DragonData.HP, 0, m_DragonData.Defense);
        }
    }
}