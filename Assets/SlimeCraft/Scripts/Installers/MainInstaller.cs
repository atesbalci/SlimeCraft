using SlimeCraft.Behaviours;
using SlimeCraft.Models;
using SlimeCraft.Views;
using UnityEngine;
using Zenject;

namespace SlimeCraft.Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private MenuStateManager menuStateManager;
        [SerializeField] private PlayerInputManager playerInputManager;
        [SerializeField] private HandView handView;
        
        public override void InstallBindings()
        {
            Container.Bind<SlimeCharacter>().AsSingle();
            Container.Bind<Inventory>().AsSingle();
            Container.BindInstance<IMenuStateManager>(menuStateManager).AsSingle();
            Container.BindInstance<IPlayerInputManager>(playerInputManager).AsSingle();
            Container.BindInstance<IHand>(handView).AsSingle();
        }
    }
}