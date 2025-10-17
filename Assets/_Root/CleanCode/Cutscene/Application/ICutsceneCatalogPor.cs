namespace _Root.CleanCode.Cutscene.Application
{
    /// <summary>
    /// Port to query metadata about cutscenes (addressable keys, skippable flag, etc.).
    /// Implemented in Infrastructure (e.g., ScriptableObject-backed catalog).
    /// </summary>
    public interface ICutsceneCatalogPort
    {
        bool TryGetSkippable(string cutsceneId, out bool skippable);
    }
}