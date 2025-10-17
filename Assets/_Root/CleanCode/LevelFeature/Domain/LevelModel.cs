namespace _Root.CleanCode.LevelFeature.Domain
{
    public readonly struct LevelStartParams
    {
        public readonly string LevelId;
        public readonly string[] AutoStartEvents;
        public readonly string InitialCutsceneId;

        public LevelStartParams(string levelId, string[] autoStartEvents, string initialCutsceneId)
        {
            LevelId = levelId;
            AutoStartEvents = autoStartEvents ?? System.Array.Empty<string>();
            InitialCutsceneId = initialCutsceneId;
        }
    }
}