using SiraUtil.Affinity;
using SiraUtil.Logging;

namespace BSMultiDifficulty.Patches
{
    internal class MpLevelLoaderPatch : IAffinity
    {
        private readonly SiraLog _log;

        public MpLevelLoaderPatch(SiraLog log)
        {
            _log = log;
        }

        [AffinityPrefix]
        [AffinityPatch(typeof(MultiplayerLevelLoader), nameof(MultiplayerLevelLoader.LoadLevel))]
        internal void Prefix(ref ILevelGameplaySetupData gameplaySetupData, float initialStartTime)
        {
            gameplaySetupData.beatmapLevel.beatmapDifficulty = BeatmapDifficulty.Easy;
            _log.Info("Overrode difficulty to easy");
        }
    }
}