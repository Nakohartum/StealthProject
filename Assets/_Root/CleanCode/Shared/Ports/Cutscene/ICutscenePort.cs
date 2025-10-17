using System;
using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Shared.Ports.Cutscene
{
    public interface ICutscenePort
    {
        bool IsPlaying { get; }

        /// <summary>Raised when a cutscene starts. Arg: cutsceneId.</summary>
        event Action<string> OnStarted;

        /// <summary>Raised when a cutscene finishes (naturally or skipped). Arg: cutsceneId.</summary>
        event Action<string> OnFinished;

        /// <summary>Begin playing a cutscene by id and await completion.</summary>
        UniTask StartAsync(string cutsceneId);

        /// <summary>Request to skip the currently playing cutscene (if policy allows).</summary>
        void Skip();
    }
}