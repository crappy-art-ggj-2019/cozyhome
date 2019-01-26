using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("HUDCanvas").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setStateHUD(string text)
    {
        Canvas.GetComponentsInChildren<TextMeshProUGUI>();
    }
}
