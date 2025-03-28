namespace _Root.Code.CutsceneFeature.Model
{
    public class CutsceneModel
    {
        public readonly CutsceneData CutsceneData;
        public int CurrentStepIndex { get; private set; } = 0;

        public CutsceneModel(CutsceneData cutsceneData)
        {
            this.CutsceneData = cutsceneData;
        }

        public CutscenePart GetCurrentCutscenePart()
        {
            if (CurrentStepIndex >= CutsceneData.CutsceneParts.Length)
            {
                return null;
            }
            return CutsceneData.CutsceneParts[CurrentStepIndex];
        }

        public bool NextStep()
        {
            CurrentStepIndex++;
            return CurrentStepIndex < CutsceneData.CutsceneParts.Length;
        }
    }
}