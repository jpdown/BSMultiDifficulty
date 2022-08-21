using BSMultiDifficulty.Patches;
using Zenject;

namespace BSMultiDifficulty.Installers
{
    internal class MenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MpLevelLoaderPatch>().AsSingle();
        }
    }
}