using Cinemachine;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public enum GameState { MainMenu, Preloader, Selection, GameCycle, Pause, GameOver, GameWon }

    public enum playerEntity { Human, Demon }
    public enum objective { TakeHome, DefendHome }

    private const float gameEndingDisplayTime = 3f;

    

    [SerializeField] Camera playView;
    [SerializeField] GameState currentstate = GameState.MainMenu;
    [SerializeField] int highScore;
    [SerializeField] PlayField playField;
    [SerializeField] UIManagerScript uiM;
    [SerializeField] playerEntity currentPlayerMode = playerEntity.Human;
    [SerializeField] public objective currentObjective = objective.DefendHome;


    float gameEndingDisplaying;
    
    private void Awake()
    {
        //Making Gamestate global, initial call in menu
        
        var doWork = SetupSingleton();
        if (!doWork)
            return;

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneManager_sceneLoaded;

        if (currentstate == GameState.MainMenu && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "MainMenu")
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    private bool SetupSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
            return false;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            return true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Gamestate"))
        {
            //currentstate = PlayerPrefs.GetInt("Currentstate");
        }
        //initialize states
    }


    // Update is called once per frame
    void Update()
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

    public void StartLevelDemon()
    {
        Debug.Log("Startlevel demon");
        currentPlayerMode = playerEntity.Demon;
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
    
    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void OnAttackerHouseEntry()
    {
        if (currentObjective == objective.DefendHome)
            setState(GameState.GameOver);
        else
            setState(GameState.GameWon);
    }
    public void OnMoveCloser(float distance)
    {
        if (uiM != null) { uiM.filldistance(distance); } else { uiM = GameObject.Find("HUDCanvas").GetComponent<UIManagerScript>(); }
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
            var sl = GameObject.Find("/SceneLoader").GetComponent<SceneLoaderScript>();
            sl.LoadMenuScene();
        }
        else if (newState == GameState.Selection)
        {
            currentstate = newState;
            var sl = GameObject.Find("/SceneLoader").GetComponent<SceneLoaderScript>();
            sl.LoadAbilityScene();
        }
        else if (newState == GameState.GameCycle)
        {
            currentstate = newState;
            Debug.Log("state:" + currentstate + " gamestate should be " + GameState.GameCycle);
            var sl = GameObject.Find("/SceneLoader").GetComponent<SceneLoaderScript>();
            sl.LoadGameScene();
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
            var monster = GameObject.Find("/monster");
            var cam = GameObject.Find("/CM vcam1").GetComponent<CinemachineVirtualCamera>();

            // Set the different views and objectives
            if (currentPlayerMode == playerEntity.Human)
            {
                cam.Follow = human.transform;
                monster.AddComponent<MonsterAIScript>();
                human.AddComponent<PlayerBehaviour>();
            }
            else
            {
                cam.Follow = monster.transform;
                human.AddComponent<HumanAIScript>();
                monster.AddComponent<PlayerBehaviour>();
            }

            if ((currentPlayerMode == playerEntity.Human && currentObjective == objective.TakeHome) 
                || (currentPlayerMode == playerEntity.Demon && currentObjective == objective.DefendHome))
            {
                human.transform.position = startPostionAttacker.position;
                monster.transform.position = startPostionDefender.position;
                human.tag = "Attacker";
                monster.tag = "Defender";
            }
            else
            {
                human.transform.position = startPostionDefender.position;
                monster.transform.position = startPostionAttacker.position;
                human.tag = "Defender";
                monster.tag = "Attacker";
            }
        }
    }
    private void SceneManager_sceneLoaded(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.LoadSceneMode arg1)
    {
        AfterSceneLoad();
    }
}
