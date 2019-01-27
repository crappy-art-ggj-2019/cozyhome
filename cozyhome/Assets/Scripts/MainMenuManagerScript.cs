using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainMenuManagerScript : MonoBehaviour
{
    [Inject]
    public GameManagerScript gmc;
    
    public void StartLevelHuman()
    {
        if (gmc != null)
        {
                gmc.StartLevelHuman();
        }
        
    }
    public void StartLevelCowman()
    {
        if (gmc != null)
        {
            gmc.StartLevelCowman();
        }

    }
}
