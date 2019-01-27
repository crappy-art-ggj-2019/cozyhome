using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    Canvas Canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("HUDCanvas").GetComponent<Canvas>();
    }

    public void setScoreHUD(string text)
    {
        TextMeshProUGUI scoreText = Canvas.GetComponentsInChildren<TextMeshProUGUI>()[0];
        scoreText.text = text;
    }
    public void setStateHUD(string text)
    {
        TextMeshProUGUI stateText = Canvas.GetComponentsInChildren<TextMeshProUGUI>()[1];
        if (stateText != null)
        {
            stateText.text = text;
        }

    }
    public void filldistance(float distance)
    {
        Image distanceimage = Canvas.GetComponentInChildren<Image>();
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
    public void setInventoryHUD(string text)
    {
        TextMeshProUGUI inventoryText = Canvas.GetComponentsInChildren<TextMeshProUGUI>()[2];
        inventoryText.text = text;
    }
}
