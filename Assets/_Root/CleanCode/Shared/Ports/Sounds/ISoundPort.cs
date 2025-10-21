using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Shared.Ports.Sounds
{
    public interface ISoundPort
    {
        void Play(string sound);
        void PlayOneShot(string sound);
        void PlayDelayed(string sound, float delay = 0f);
        void PreloadSound(string sound);
        void Stop(string sound);
    }
}