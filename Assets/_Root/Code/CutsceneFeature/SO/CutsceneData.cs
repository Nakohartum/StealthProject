using System.Collections.Generic;
using UnityEngine;

namespace _Root.Code.CutsceneFeature.Model
{
    [CreateAssetMenu(fileName = "CutsceneData", menuName = "Create/Cutscene", order = 0)]
    public class CutsceneData : ScriptableObject
    {
        public string CutsceneID;
        public CutscenePart[] CutsceneParts;
    }
}