using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var gmc = GameObject.Find("/GameManagerController").GetComponent<GameManagerScript>();
            gmc.OnHouseEntry();
        }
    }
}
