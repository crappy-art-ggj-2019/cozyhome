using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EndingPanelScript : MonoBehaviour
{
    [Inject]
    public SceneLoaderScript SceneLoader;

    public void Continue()
    {
        SceneLoader.LoadMenuScene();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
