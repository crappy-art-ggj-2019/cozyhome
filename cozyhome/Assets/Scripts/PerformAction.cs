using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformAction : MonoBehaviour
{
    public Transform ownerObject;
    public GameObject resolutionPrefab;
    public float coolDown;
    public Color coolDownColor;

    private float currentCoolDown = 0;
    
    void Update()
    {
        if (currentCoolDown > Time.time)
            GetComponent<Image>().color = coolDownColor;
        else
            GetComponent<Image>().color = Color.white;
    }

    public void DoTheThing()
    {
        //print("Doing the thing!");

        if (Time.time > currentCoolDown)
        {
            Instantiate(resolutionPrefab, ownerObject.position, ownerObject.rotation);
            currentCoolDown = Time.time + coolDown;
        }
    }
}
