namespace _Root.CleanCode.Shared.Ports.Move
{
    public interface IMovePort
    {
        void Move(Vec2 direction);
        void Rotate(Vec2 direction);
    }
}