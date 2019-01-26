using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    Canvas Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("HUDCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        distanceimage.fillAmount = distance;
    }
    public void setInventoryHUD(string text)
    {
        TextMeshProUGUI inventoryText = Canvas.GetComponentsInChildren<TextMeshProUGUI>()[2];
        inventoryText.text = text;
    }
}
