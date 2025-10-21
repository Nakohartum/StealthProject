using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.QuestFeature.Infrastructure
{
    public class PerSceneQuestsInstaller : MonoInstaller
    {
        [Header("Rules")]
        [SerializeField] private List<ScriptableQuestStartRules> _rules = new List<ScriptableQuestStartRules>();

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<QuestStartByRuleSystem>().AsSingle().WithArguments(_rules);
            Container.BindInterfacesAndSelfTo<QuestStartTimerSystem>().AsSingle().WithArguments(_rules);
        }
    }
}