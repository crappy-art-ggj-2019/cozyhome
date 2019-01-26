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
    public void setStateHUD(string text)
    {
        TextMeshProUGUI stateText = Canvas.GetComponentsInChildren<TextMeshProUGUI>()[1];
        stateText.text = text;

    }
}
