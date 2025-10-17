using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Shared.Ports.Sounds
{
    public interface ISoundPortAsync
    {
        UniTask PlayAsync(string sound);
        UniTask PlayOneShotAsync(string sound);
        UniTask PlayDelayedAsync(string sound, float delay = 0f);
        void Stop(string sound);
    }
}