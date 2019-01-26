using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    enum GameState { MainMenu, Preloader, Selection, GameCycle, Pause, GameOver }
    
    enum playerEntity { Human, Demon }
    
    
    [SerializeField] enum winCondition { Human, Demon }
    [SerializeField] Camera playView;
    [SerializeField] GameState currentstate;
    [SerializeField] int highScore;
    [SerializeField] PlayField playField;
    [SerializeField] UIManagerScript uiM;
    
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
        setState("Playing");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setState(string state)
    {
        //currentstate = (GameState)state;
        uiM = GameObject.Find("UIManager").GetComponent<UIManagerScript>();
        uiM.setStateHUD(state);

    }


}
