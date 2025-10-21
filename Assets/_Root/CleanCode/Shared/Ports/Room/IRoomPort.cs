using System;
using Unity.Plastic.Newtonsoft.Json.Serialization;

namespace _Root.CleanCode.Shared.Ports.Room
{
    public interface IRoomPort
    {
        event Action<bool> OnPlayerEnteredRoom;
        event Action<bool> OnPlayerLeftRoom;
    }
}