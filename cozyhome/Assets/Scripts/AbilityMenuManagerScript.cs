using UnityEngine;
using Zenject;

public class AbilityMenuManagerScript : MonoBehaviour
{
    [Inject]
    public GameManagerScript gmc;


    public void StartLevel()
    {
        if (gmc != null)
        {
            gmc.StartGameplay();
        }
    }
}
