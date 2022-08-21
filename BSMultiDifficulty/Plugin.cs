using BSMultiDifficulty.Installers;
using IPA;
using IPALogger = IPA.Logging.Logger;
using SiraUtil.Zenject;

namespace BSMultiDifficulty
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        [Init]
        public Plugin(IPALogger logger, Zenjector zenjector)
        {
            zenjector.UseLogger(logger);
            zenjector.Install<MenuInstaller>(Location.Menu);
        }
    }
}