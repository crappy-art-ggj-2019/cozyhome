using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCollider : MonoBehaviour
{
    private GameManagerScript gmc;

    void Awake()
    {
        gmc = GameObject.Find("/GameManagerController").GetComponent<GameManagerScript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gmc.currentObjective == GameManagerScript.objective.TakeHome && collision.tag == "Player")
        {
            gmc.OnHouseEntry();
        }
    }
}
