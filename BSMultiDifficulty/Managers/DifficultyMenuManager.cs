using System;
using BeatSaberMarkupLanguage.GameplaySetup;
using BSMultiDifficulty.UI;
using SiraUtil.Logging;
using Zenject;

namespace BSMultiDifficulty.Managers
{
    internal class DifficultyMenuManager : IInitializable, IDisposable
    {
        private readonly DifficultyView _difficultyView;
        private readonly SiraLog _log;

        public DifficultyMenuManager(DifficultyView difficultyView, SiraLog log)
        {
            _difficultyView = difficultyView;
            _log = log;
        }

        public void Dispose()
        {
            if (GameplaySetup.IsSingletonAvailable)
            {
                GameplaySetup.instance.RemoveTab("BSMultiDifficulty");
            }
        }

        public void Initialize()
        {
            _log.Info("Initialize");
            GameplaySetup.instance.AddTab("BSMultiDifficulty", "BSMultiDifficulty.UI.DifficultyView.bsml", _difficultyView, MenuType.Online);
        }
    }
}