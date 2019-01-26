﻿using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public enum GameState { MainMenu, Preloader, Selection, GameCycle, Pause, GameOver, GameWon }
    
    enum playerEntity { Human, Demon }

    private const float gameEndingDisplayTime = 3f;

    
    [SerializeField] enum winCondition { Human, Demon }
    [SerializeField] Camera playView;
    [SerializeField] GameState currentstate = GameState.MainMenu;
    [SerializeField] int highScore;
    [SerializeField] PlayField playField;
    [SerializeField] UIManagerScript uiM;
    [SerializeField] playerEntity currentPlayerMode = playerEntity.Human;


    float gameEndingDisplaying;
    
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
        setState(GameState.GameCycle);
    }

    public void StartLevelDemon()
    {
        Debug.Log("Startlevel demon");
        currentPlayerMode = playerEntity.Demon;
        setState(GameState.GameCycle);
    }


    public void OnHouseEntry()
    {
        if (currentPlayerMode == playerEntity.Demon)
            setState(GameState.GameOver);
        else
            setState(GameState.GameWon);
    }


    private void setState(GameState state)
    {
        Debug.Log("Set gamestate");
        currentstate = state;
        if (currentstate == GameState.GameOver)
        {
            uiM = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
            uiM.setStateHUD(state.ToString());
            gameEndingDisplaying = Time.time + gameEndingDisplayTime;
        }
        else if (currentstate == GameState.GameWon)
        {
            uiM = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
            uiM.setStateHUD(state.ToString());
            gameEndingDisplaying = Time.time + gameEndingDisplayTime;
        }
        else if (currentstate == GameState.MainMenu)
        {
            var sl = GameObject.Find("SceneLoader").GetComponent<SceneLoaderScript>();
            sl.LoadMenuScene();
        }
        else if (currentstate == GameState.GameCycle)
        {
            Debug.Log("state:" + currentstate + " gamestate should be " + GameState.GameCycle);
            var sl = GameObject.Find("SceneLoader").GetComponent<SceneLoaderScript>();
            sl.LoadGameScene();
        }
    }
}
