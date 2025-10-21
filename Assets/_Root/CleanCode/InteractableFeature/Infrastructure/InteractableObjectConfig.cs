using _Root.CleanCode.InteractableFeature.Domain;
using UnityEngine;

namespace _Root.CleanCode.InteractableFeature.Infrastructure
{
    [CreateAssetMenu(fileName = nameof(InteractableObjectConfig), menuName = "Create/InteractableObject/"+nameof(InteractableObjectConfig), order = 0)]
    public class InteractableObjectConfig : ScriptableObject
    {
        public string StartSoundKey;
        public string ContinuousSoundKey;
        public string StopSoundKey;
        public string DialogKey;

        public InteractableModel ToModel()
        {
            return new InteractableModel
            {
                StartSoundKey = StartSoundKey,
                ContinuousSoundKey = ContinuousSoundKey,
                StopSoundKey = StopSoundKey,
                DialogKey = DialogKey
            };
        }
    }
}