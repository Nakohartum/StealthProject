namespace _Root.CleanCode.Cutscene.Domain
{
    public readonly struct CutsceneId
    {
        public string Value { get; }

        public CutsceneId(string value)
        {
            Value = value ?? "";
        }
        
        public override string ToString() => Value;
    }
}