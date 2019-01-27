using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        SceneManager.LoadScene("GamePlay");
    }
    public void LoadAbilityScene()
    {
        SceneManager.LoadScene("AbilityMenu");
    }
    public void LoadSecretLevel()
    {
        SceneManager.LoadScene("SecretEnding");
    }
    public void LoadSecretBLevel()
    {
        SceneManager.LoadScene("SecretEndingBad");
    }
    
}
