using UnityEngine;

namespace GOEGame.Modules
{
    public class TestModule:GOEModule
    {
        public override void Start()
        {
            base.Start();
            Debug.Log("开始游戏");
        }
    }
}