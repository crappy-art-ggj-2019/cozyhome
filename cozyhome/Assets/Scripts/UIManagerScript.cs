using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIManagerScript : MonoBehaviour
{
    [Inject]
    public GameManagerScript gmc;

    Canvas SCanvas;
    [SerializeField] GameObject PPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        SCanvas = GameObject.Find("HUDCanvas").GetComponent<Canvas>();
        //PPanel = GameObject.Find("PausePanel").GetComponent<GameObject>();
    }
    private void Update()
    {
        Debug.Log("updating");
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape pressed");
            PPanel.SetActive(!PPanel.activeSelf);
        }   
    }
    public void ResumeGame()
    {
        PPanel.SetActive(false);
    }
    public void toMainMenu()
    {
        if (gmc != null)
        {
            gmc.StartMainMenu();
        }
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void setStateHUD(string text)
    {
        TextMeshProUGUI stateText = SCanvas.GetComponentsInChildren<TextMeshProUGUI>()[0];
        if (stateText != null)
        {
            stateText.text = text;
        }

    }
    public void filldistance(float distance)
    {
        Image distanceimage = SCanvas.GetComponentInChildren<Image>();
        if (distance > 0.5f)
        {
            distanceimage.color = Color.red;
        }
        else
        {
            distanceimage.color = Color.blue;
        }
        distanceimage.fillAmount = distance;
    }
}
