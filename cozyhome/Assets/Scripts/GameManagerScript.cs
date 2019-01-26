using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public enum GameState { MainMenu, Preloader, Selection, GameCycle, Pause, GameOver }
    
    enum playerEntity { Human, Demon }

    private const float triggerDistance = 0.01f;
    private const float timeOfDeath = 3f;

    
    [SerializeField] enum winCondition { Human, Demon }
    [SerializeField] Camera playView;
    [SerializeField] GameState currentstate;
    [SerializeField] int highScore;
    [SerializeField] PlayField playField = new PlayField();
    [SerializeField] UIManagerScript uiM;

    float dieSwitchTime;
    
    private void Awake()
    {
        //Making Gamestate global, initial call in menu
        
        SetupSingleton();

    }
    private void SetupSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
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
        setState(GameState.MainMenu);
    }


    // Update is called once per frame
    void Update()
    {
        if (currentstate == GameState.GameCycle)
        {
            //
        }
        if (currentstate == GameState.GameOver)
        {
            if (Time.time > dieSwitchTime)
                setState(GameState.MainMenu);
        }
    }

    public void StartLevel()
    {
        setState(GameState.GameCycle);
    }


    public void OnHouseEntry()
    {
        setState(GameState.GameOver);
    }


    private void setState(GameState state)
    {
        currentstate = state;
        if (currentstate == GameState.GameOver)
        {
            uiM = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
            uiM.setStateHUD(state.ToString());
            dieSwitchTime = Time.time + timeOfDeath;
        }
        else if (currentstate == GameState.MainMenu)
        {
            var sl = GameObject.Find("SceneLoader").GetComponent<SceneLoaderScript>();
            sl.LoadMenuScene();
        }
        else if (currentstate == GameState.GameCycle)
        {
            var sl = GameObject.Find("SceneLoader").GetComponent<SceneLoaderScript>();
            sl.LoadGameScene();
        }
    }
}
