using Assets.Scripts.DI_Framework;
using Zenject;

public class RootInstaller : MonoInstaller<RootInstaller>
{
    public GlobalSoundPlayer GlobalSoundPlayer;

    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.BindInterfacesAndSelfTo<GameManagerScript>().AsSingle().NonLazy();
        Container.Bind<SceneLoaderScript>().AsSingle();
        Container.Bind<InjectorHelper>().AsTransient();
        Container.BindInstances(GlobalSoundPlayer);
    }
}
