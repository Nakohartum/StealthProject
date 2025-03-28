using System.Linq;
using UnityEngine;

namespace _Root.Code.CutsceneFeature.Model
{
    [CreateAssetMenu(fileName = "CutsceneRegistry", menuName = "Create/CutsceneRegistry", order = 0)]
    public class CutsceneRegistry : ScriptableObject
    {
        [SerializeField] private CutsceneData[] _cutscenes;

        public CutsceneData this[string cutsceneName]
        {
            get
            {
                return _cutscenes.First(cutscene => cutscene.CutsceneID == cutsceneName);
            }
        }
    }
}