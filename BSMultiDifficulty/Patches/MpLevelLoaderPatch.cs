using BSMultiDifficulty.Managers;
using SiraUtil.Affinity;
using SiraUtil.Logging;

namespace BSMultiDifficulty.Patches
{
    internal class MpLevelLoaderPatch : IAffinity
    {
        private readonly DifficultyOverrideManager _difficultyOverrideManager;
        private readonly SiraLog _log;

        public MpLevelLoaderPatch(DifficultyOverrideManager difficultyOverrideManager, SiraLog log)
        {
            _difficultyOverrideManager = difficultyOverrideManager;
            _log = log;
        }

        [AffinityPrefix]
        [AffinityPatch(typeof(MultiplayerLevelLoader), nameof(MultiplayerLevelLoader.LoadLevel))]
        internal void Prefix(ref ILevelGameplaySetupData gameplaySetupData, float initialStartTime)
        {
            if (_difficultyOverrideManager.Enabled)
            {
                gameplaySetupData.beatmapLevel.beatmapDifficulty = _difficultyOverrideManager.ChosenDifficulty;
                _log.Info("Difficulty overridden to " + _difficultyOverrideManager.ChosenDifficulty);
            }
        }
    }
}