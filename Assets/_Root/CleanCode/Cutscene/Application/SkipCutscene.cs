namespace _Root.CleanCode.Cutscene.Application
{
    /// <summary>Use case: skip the currently playing cutscene, if any.</summary>
    public sealed class SkipCutscene
    {
        private readonly ICutscenePlayerPort _player;

        public SkipCutscene(ICutscenePlayerPort player)
        {
            _player = player;
        }

        public void Execute()
        {
            if (_player.IsPlaying)
            {
                _player.Stop();
            }
        }
    }
}