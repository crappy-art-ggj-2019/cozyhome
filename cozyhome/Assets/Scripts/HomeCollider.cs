using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HomeCollider : MonoBehaviour
{
    [Inject]
    public GameManagerScript gmc;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gmc.currentObjective == GameManagerScript.objective.TakeHome && collision.tag == "Attacker")
        {
            AudioClip clip;
            
            clip = Resources.Load<AudioClip>("cowmandies");
            AudioSource.PlayClipAtPoint(clip, new Vector2(0, 0));
            gmc.OnAttackerHouseEntry();
            
        }
    }
}
