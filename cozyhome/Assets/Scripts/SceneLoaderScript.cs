using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript
{
    public void EnsureMainMenu()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
            SceneManager.LoadScene("MainMenu");
    }
    

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
