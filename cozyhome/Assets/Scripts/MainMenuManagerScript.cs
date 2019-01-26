using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManagerScript : MonoBehaviour
{
    GameManagerScript gmc;
    
    // Start is called before the first frame update
    void Start()
    {
        gmc = GameObject.Find("GameManagerController").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartLevelHuman()
    {
        if (gmc != null)
        {
                gmc.StartLevelHuman();
        }
        
    }
    public void StartLevelDemon()
    {
        if (gmc != null)
        {
            gmc.StartLevelDemon();
        }

    }
}
