using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Cutscene.Application
{
    public interface ICutscenePlayerPort
    {
        /// <summary>Loads and plays the cutscene by id, waits until it completes or is stopped.</summary>
        UniTask PlayAsync(string cutsceneId);

        /// <summary>Stops the currently playing cutscene immediately (used for skip).</summary>
        void Stop();

        /// <summary>True while the underlying player is actively playing.</summary>
        bool IsPlaying { get; }
    }
}