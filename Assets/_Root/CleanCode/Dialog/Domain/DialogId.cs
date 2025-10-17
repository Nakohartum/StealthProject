namespace _Root.CleanCode.Dialog.Domain
{
    public readonly struct DialogId
    {
        public string Value { get; }
        public DialogId(string value) => Value = value;
        public override string ToString() => Value;
    }
}