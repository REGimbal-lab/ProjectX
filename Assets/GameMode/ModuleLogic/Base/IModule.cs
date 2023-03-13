namespace GOEGame
{
    public interface IModule
    {
        void Start();
        
        void ClearData();
        
        void Dispose();
        
        bool NeedUpdate();
    }

    public interface IUpdate
    {
        void Update(float deltaTime);
        
        void LateUpdate();
        
        bool Enable { get; }
        
    }
}