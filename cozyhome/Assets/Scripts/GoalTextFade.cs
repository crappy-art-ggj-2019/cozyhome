using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTextFade : MonoBehaviour
{
    public Text textChild;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetComponent<Image>().color = new Color32(85, 85, 85, 0);

            textChild.color = new Color32(255, 255, 255, 0);
        }
    }
}
