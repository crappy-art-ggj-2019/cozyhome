﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformAction : MonoBehaviour
{
    public Transform ownerObject;
    public GameObject resolutionPrefab;
    public float coolDown;
    public Color coolDownColor;

    private Color initialColor;
    private float currentCoolDown = 0;

    void Start()
    {
        initialColor = GetComponent<Image>().color;
    }

    void Update()
    {
        if (currentCoolDown > Time.time)
            GetComponent<Image>().color = coolDownColor;
        else
            GetComponent<Image>().color = initialColor;
    }

    public void SetColor(Color newColor)
    {
        initialColor = newColor;
    }

    public void DoTheThing()
    {
        //Debug.Log("Doing the thing!");

        if (Time.time > currentCoolDown)
        {
            Instantiate(resolutionPrefab, ownerObject.position, ownerObject.rotation);
            currentCoolDown = Time.time + coolDown;
        }
    }
}
