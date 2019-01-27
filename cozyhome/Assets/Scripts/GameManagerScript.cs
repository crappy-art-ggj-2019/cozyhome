using Assets.Scripts.DI_Framework;
using Cinemachine;
using UnityEngine;
using Zenject;

public class GameManagerScript : IInitializable, IFixedTickable
{
    public enum GameState { MainMenu, Preloader, Selection, GameCycle, Pause, GameOver, GameWon, SecretFound, SecretDestroyed }

    public enum playerEntity { Human, Cowman }
    public enum objective { TakeHome, DefendHome }

    private const float gameEndingDisplayTime = 3f;
    private readonly SceneLoaderScript sceneLoader;
    private readonly InjectorHelper injectorHelper;
    [SerializeField] Camera playView;
    [SerializeField] GameState currentstate = GameState.MainMenu;
    [SerializeField] int highScore;
    [SerializeField] PlayField playField;
    [SerializeField] UIManagerScript uiM;
    [SerializeField] playerEntity currentPlayerMode = playerEntity.Human;
    [SerializeField] public objective currentObjective = objective.DefendHome;


    float gameEndingDisplaying;

    public GameManagerScript(SceneLoaderScript sceneLoader, InjectorHelper injectorHelper)
    {
        this.sceneLoader = sceneLoader;
        this.injectorHelper = injectorHelper;
    }

    public void Initialize()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneManager_sceneLoaded;

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
        Debug.Log("Startlevel human");
        currentPlayerMode = playerEntity.Human;
        setState(GameState.Selection);
    }

    public void StartLevelCowman()
    {
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

    private void AfterSceneLoad()
    {
        if (currentstate == GameState.GameCycle)
        {
            if (currentObjective == objective.TakeHome)
                currentObjective = objective.DefendHome;
            else 
                currentObjective = objective.TakeHome;

            var startPostionAttacker = GameObject.Find("/StartingPositionAttacker").transform;
            var startPostionDefender = GameObject.Find("/StartingPositionDefender").transform;
            var human = GameObject.Find("/human");
            var cowman = GameObject.Find("/cowman");
            var cam = GameObject.Find("/CM vcam1").GetComponent<CinemachineVirtualCamera>();

            // Set the different views and objectives
            if (currentPlayerMode == playerEntity.Human)
            {
                cam.Follow = human.transform;

                injectorHelper.AddComponentToGameObject<CowmanAIScript>(cowman);
                injectorHelper.AddComponentToGameObject<PlayerBehaviour>(human);
            }
            else
            {
                cam.Follow = cowman.transform;
                injectorHelper.AddComponentToGameObject<HumanAIScript>(human);
                injectorHelper.AddComponentToGameObject<PlayerBehaviour>(cowman);
            }

            if ((currentPlayerMode == playerEntity.Human && currentObjective == objective.TakeHome) 
                || (currentPlayerMode == playerEntity.Cowman && currentObjective == objective.DefendHome))
            {
                human.transform.position = startPostionAttacker.position;
                cowman.transform.position = startPostionDefender.position;
                human.tag = "Attacker";
                cowman.tag = "Defender";
            }
            else
            {
                human.transform.position = startPostionDefender.position;
                cowman.transform.position = startPostionAttacker.position;
                human.tag = "Defender";
                cowman.tag = "Attacker";
            }
        }
    }
    private void SceneManager_sceneLoaded(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.LoadSceneMode arg1)
    {
        AfterSceneLoad();
    }
}
