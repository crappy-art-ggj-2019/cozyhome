using UnityEngine;
using UnityEditor;
using Zenject;
using static GameManagerScript;

public class LevelStartHelper : IInitializable
{
    private readonly GameManagerScript gameManager;
    private readonly SignalBus signalBus;

    public LevelStartHelper(GameManagerScript gameManager, SignalBus signalBus)
    {
        this.gameManager = gameManager;
        this.signalBus = signalBus;
    }

    public void Initialize()
    {
        if (gameManager.currentstate == GameState.GameCycle)
        {
            signalBus.Fire(new LevelStartSignal { currentPlayerMode = gameManager.currentPlayerMode });
        }
    }
}