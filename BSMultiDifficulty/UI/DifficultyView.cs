using System;
using System.Collections.Generic;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using BSMultiDifficulty.Managers;
using HMUI;
using SiraUtil.Logging;
using Zenject;

namespace BSMultiDifficulty.UI
{
    [HotReload(RelativePathToLayout = @"DifficultyView.bsml")]
    [ViewDefinition("BSMultiDifficulty.UI.DifficultyView.bsml")]
    internal class DifficultyView : BSMLAutomaticViewController
    {
        private SiraLog _log;
        private DifficultyOverrideManager _difficultyOverrideManager;

        [UIValue("toggle-override")]
        private bool ToggleOverride
        {
            get => _difficultyOverrideManager.Enabled;
            set => _difficultyOverrideManager.Enabled = value;
        }
        
        [UIValue("difficulties")]
        private List<BeatmapDifficulty> Difficulties => _difficultyOverrideManager.ValidDifficulties;

        [UIAction("choose-difficulty")]
        private void ChooseDifficulty(SegmentedControl control, int index)
        {
            var difficulty = Difficulties[index];
            _log.Debug("In choose difficulty, " + difficulty);
            _difficultyOverrideManager.SetDifficulty(difficulty);
        }

        [Inject]
        public void Construct(DifficultyOverrideManager difficultyOverrideManager, SiraLog log)
        {
            _difficultyOverrideManager = difficultyOverrideManager;
            _log = log;
        }
    }
}