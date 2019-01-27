using System.Collections.Generic;
using Assets.Scripts.DI_Framework;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameManagerScript : IInitializable, IFixedTickable
{
    public enum GameState { MainMenu, Preloader, Selection, GameCycle, Pause, GameOver, GameWon, SecretFound, SecretDestroyed }

    public enum playerEntity { Human, Cowman }
    public enum objective { TakeHome, DefendHome }

    private const float gameEndingDisplayTime = 3f;
    private readonly SceneLoaderScript sceneLoader;
    private readonly InjectorHelper injectorHelper;
    private readonly SignalBus signalBus;
    private readonly GameStartMechanicsScript gameStartMechanics;
    [SerializeField] Camera playView;
    [SerializeField] public GameState currentstate = GameState.MainMenu;
    [SerializeField] int highScore;
    [SerializeField] PlayField playField;
    [SerializeField] UIManagerScript uiM;
    [SerializeField] public playerEntity currentPlayerMode = playerEntity.Human;
    [SerializeField] public objective currentObjective = objective.DefendHome;
    AudioClip humanButtonClip, cowButtonClip;


    float gameEndingDisplaying;

    public GameManagerScript(SceneLoaderScript sceneLoader, InjectorHelper injectorHelper, SignalBus signalBus)
    {
        this.sceneLoader = sceneLoader;
        this.injectorHelper = injectorHelper;
        this.signalBus = signalBus;
    }

    public void Initialize()
    {
        sceneLoader.EnsureMainMenu();
    }

    // Update is called once per frame
    public void FixedTick()
    {
        if (currentstate == GameState.GameCycle)
        {
            //
        }
        else if (currentstate == GameState.GameOver || currentstate == GameState.GameWon)
        {
            if (Time.time > gameEndingDisplaying)
                setState(GameState.MainMenu);
        }
    }

    public void StartLevelHuman()
    {
        humanButtonClip = Resources.Load<AudioClip>("footstep00");
        AudioSource.PlayClipAtPoint(humanButtonClip, new Vector3(0, 0,0));
        Debug.Log("Startlevel human");
        currentPlayerMode = playerEntity.Human;
        setState(GameState.Selection);
    }

    public void StartLevelCowman()
    {
        cowButtonClip = Resources.Load<AudioClip>("cowbell");
        AudioSource.PlayClipAtPoint(cowButtonClip, new Vector3(0,0,0));
        Debug.Log("Startlevel cowman");
        currentPlayerMode = playerEntity.Cowman;
        setState(GameState.Selection);
    }

    public void StartGameplay()
    {
        Debug.Log("Start gameplay");
        setState(GameState.GameCycle);
    }
    public void StartMainMenu()
    {
        Debug.Log("Start Menu");
        setState(GameState.MainMenu);
    }
    public void Stashway()
    {
        
    }
    public void Stashback()
    {

    }

    public void OnMeteor()
    {
        setState(GameState.GameOver);
    }

    public void OnAttackerHouseEntry()
    {
        if (currentObjective == objective.DefendHome)
            setState(GameState.GameOver);
        else
            setState(GameState.GameWon);
    }
    //distance to goal
    public void OnMoveCloser(float distance)
    {
        uiM = GameObject.Find("UIManager")?.GetComponent<UIManagerScript>();
        if (uiM != null)
            uiM.filldistance(distance); 
    }
    public void OnAvatarGet()
    {
        if (currentObjective == objective.TakeHome)
            setState(GameState.GameOver);
        else
            setState(GameState.GameWon);
    }

    private void setState(GameState newState)
    {
        Debug.Log("Set gamestate");
        if (newState == GameState.MainMenu)
        {
            currentstate = newState;
            sceneLoader.LoadMenuScene();
        }
        else if (newState == GameState.Selection)
        {
            currentstate = newState;
            sceneLoader.LoadAbilityScene();
        }
        else if (newState == GameState.GameCycle)
        {
            currentstate = newState;
            Debug.Log("state:" + currentstate + " gamestate should be " + GameState.GameCycle);
            sceneLoader.LoadGameScene();
        }
        else if (currentstate == GameState.GameCycle && newState == GameState.GameOver)
        {
            currentstate = newState;
            uiM = GameObject.Find("/UIManager").GetComponent<UIManagerScript>();
            uiM.setStateHUD(newState.ToString());
            gameEndingDisplaying = Time.time + gameEndingDisplayTime;
        }
        else if (currentstate == GameState.GameCycle && newState == GameState.GameWon)
        {
            currentstate = newState;
            uiM = GameObject.Find("/UIManager").GetComponent<UIManagerScript>();
            uiM.setStateHUD(newState.ToString());
            gameEndingDisplaying = Time.time + gameEndingDisplayTime;
        }
    }
}
