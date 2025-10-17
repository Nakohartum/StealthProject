using _Root.CleanCode.Shared.Ports;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Shared._Root.CleanCode.Shared
{
    public class AddressablesHelper : IAddressablesPort
    {
        public async UniTask<T> LoadAsync<T>(string key)
        {
            AsyncOperationHandle<T> handler = Addressables.LoadAssetAsync<T>(key);
            await handler.ToUniTask();
            
            return handler.Result;
        }

        public async UniTask UnloadAsync(object handle)
        {
            if (handle is AsyncOperationHandle h)
            {
                Addressables.Release(h);
                await UniTask.Yield();
            }
            else if (handle != null)
            {
                Addressables.Release(handle);
                await UniTask.Yield();
            }
        }
    }
}