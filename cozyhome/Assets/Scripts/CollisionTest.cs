using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(name + " collided with " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        print(name + " was triggered by " + trigger.name);
    }
}
