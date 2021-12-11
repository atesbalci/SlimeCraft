using SlimeCraft.Models;
using Zenject;

namespace SlimeCraft.Installers
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SlimeCharacter>().AsSingle();
            Container.Bind<Inventory>().AsSingle();
        }
    }
}