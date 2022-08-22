using BSMultiDifficulty.Managers;
using BSMultiDifficulty.Patches;
using BSMultiDifficulty.UI;
using Zenject;

namespace BSMultiDifficulty.Installers
{
    internal class MenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<DifficultyView>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesAndSelfTo<DifficultyOverrideManager>().AsSingle();
            Container.BindInterfacesTo<MpLevelLoaderPatch>().AsSingle();
            Container.BindInterfacesTo<DifficultyMenuManager>().AsSingle();
        }
    }
}