using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public List<string> blocks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (string block in blocks)
        {
            // if not supposed to block
            if (!blocks.Contains(collision.gameObject.tag))
            {
                // ignore this specific collision
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }

            // if it's a player and supposed to block
            if (block == "Player" && collision.gameObject.CompareTag(block))
                // call its "StopMoving" function to make it stop moving
                collision.gameObject.GetComponent<PlayerBehaviour>().StopMoving();
        }
    }
}
