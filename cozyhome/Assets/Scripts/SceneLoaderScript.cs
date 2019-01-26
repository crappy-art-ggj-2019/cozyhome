using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{



    // Start is called before the first frame update
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameScene()
    {
        Debug.Log("Start game");
        SceneManager.LoadScene(1);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
