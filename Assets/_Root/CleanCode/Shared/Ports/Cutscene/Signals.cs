namespace _Root.CleanCode.Shared.Ports.Cutscene
{
    public readonly struct CutscenePlaySignal
    {
        public readonly string CutsceneId;
        public CutscenePlaySignal(string cutsceneId) { CutsceneId = cutsceneId; }
    }
    public readonly struct CutsceneFinishedSignal
    {
        public readonly string CutsceneId;
    }
}