using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePlayInstaller : MonoInstaller<RootInstaller>
{
    public GameStartMechanicsScript GameStartMechanics;

    public override void InstallBindings()
    {
        Container.BindInstance(GameStartMechanics);
        Container.BindInterfacesAndSelfTo<LevelStartHelper>().AsTransient();


        Container.DeclareSignal<LevelStartSignal>();

        Container.BindSignal<LevelStartSignal>()
            .ToMethod<GameStartMechanicsScript>(x => x.OnGameStartSignal)
            .FromResolve();
    }
}
