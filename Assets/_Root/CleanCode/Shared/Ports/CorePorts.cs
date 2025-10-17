using System.Collections.Generic;
using System.Numerics;
using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Shared.Ports
{
    public interface ITime
    {
        /// <summary>Delta time in seconds since last tick.</summary>
        float DeltaTime { get; }
        /// <summary>Time in seconds since app start.</summary>
        float TimeSinceStart { get; }
    }

    /// <summary>
    /// Input boundary consumed by Application layer (e.g., player use-cases).
    /// </summary>

    /// <summary>
    /// Pathfinding boundary abstracting custom A* (no Unity types).
    /// </summary>
    

    public interface IAddressablesPort
    {
        UniTask<T> LoadAsync<T>(string key);
        UniTask UnloadAsync(object handle);
    }
}