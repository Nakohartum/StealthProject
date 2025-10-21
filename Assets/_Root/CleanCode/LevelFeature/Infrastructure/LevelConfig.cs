using UnityEngine;

namespace _Root.CleanCode.LevelFeature.Infrastructure
{
    [CreateAssetMenu(menuName = "Game/Level Config", fileName = "LevelConfig")]
    public sealed class LevelConfig : ScriptableObject
    {
        [Tooltip("Logical ID for analytics, saves, events.")]
        public string LevelId = "Level01";

        [Tooltip("Events to publish automatically on Start (e.g., \"Quest/Start:Intro\").")]
        public string[] AutoStartEvents;

        [Tooltip("Cutscene to play immediately on level start (optional).")]
        public string InitialCutsceneId;
        
    }
}