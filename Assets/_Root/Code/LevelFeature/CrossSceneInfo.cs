using GameOne.Player;
using UnityEngine;

namespace _Root.Code.LevelFeature
{
    [CreateAssetMenu(fileName = nameof(CrossSceneInfo), menuName = "Create/"+nameof(CrossSceneInfo), order = 0)]
    public class CrossSceneInfo : ScriptableObject
    {
        public PlayerView PlayerView;
    }
}