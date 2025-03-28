using UnityEngine;

namespace _Root.Code.CutsceneFeature.Model
{
    [CreateAssetMenu(fileName = "CutscenePart", menuName = "Create/Cutscene Part")]
    public class CutscenePart : ScriptableObject
    {
        public string Dialog;
        public Sprite CharacterSprite;
        public string CharacterName;
    }
}