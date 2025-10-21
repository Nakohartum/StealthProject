namespace _Root.CleanCode.Shared.Ports
{
    public readonly struct Result
    {
        public readonly bool IsOk;
        public readonly string Error;

        private Result(bool ok, string error) { IsOk = ok; Error = error; }

        public static Result Ok() => new(true, "");
        public static Result Fail(string error) => new(false, error);

        public override string ToString() => IsOk ? "Ok" : $"Fail({Error})";
    }

    /// <summary>
    /// Result with payload.
    /// </summary>
    public readonly struct Result<T>
    {
        public readonly bool IsOk;
        public readonly string Error;
        public readonly T Value;

        private Result(bool ok, T value, string error) { IsOk = ok; Value = value; Error = error; }

        public static Result<T> Ok(T value) => new(true, value, "");
        public static Result<T> Fail(string error) => new(false, default!, error);

        public void Deconstruct(out bool ok, out T value, out string error)
        {
            ok = IsOk; value = Value; error = Error;
        }

        public override string ToString() => IsOk ? $"Ok({Value})" : $"Fail({Error})";
    }
}