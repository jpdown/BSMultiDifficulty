using System.Collections.Generic;
using Zenject;

namespace BSMultiDifficulty.Managers
{
    public class DifficultyOverrideManager : IInitializable
    {
        public bool Enabled { get; set; }
        public BeatmapDifficulty ChosenDifficulty { get; private set; }
        public List<BeatmapDifficulty> ValidDifficulties { get; private set; }
        
        public void Initialize()
        {
            Enabled = false;
            ChosenDifficulty = BeatmapDifficulty.ExpertPlus;
            ValidDifficulties = new List<BeatmapDifficulty>
            {
                BeatmapDifficulty.Easy,
                BeatmapDifficulty.Normal,
                BeatmapDifficulty.Hard,
                BeatmapDifficulty.Expert,
                BeatmapDifficulty.ExpertPlus
            };
        }

        public void SetDifficulty(BeatmapDifficulty difficulty)
        {
            // Will ensure valid difficulty later
            ChosenDifficulty = difficulty;
        }
    }
}