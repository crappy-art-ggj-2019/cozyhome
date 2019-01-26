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
        
    }
    public void setState(int state)
    {
        currentstate = (GameState)state;
    }


}
