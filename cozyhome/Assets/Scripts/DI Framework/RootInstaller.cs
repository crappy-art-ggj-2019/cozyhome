using Assets.Scripts.DI_Framework;
using Zenject;

public class RootInstaller : MonoInstaller<RootInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameManagerScript>().AsSingle().NonLazy();
        Container.Bind<SceneLoaderScript>().AsSingle();
        Container.Bind<InjectorHelper>().AsTransient();
    }
}
