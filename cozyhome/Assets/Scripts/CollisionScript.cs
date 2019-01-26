using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public string[] blocks;

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
        foreach (string block in blocks)
        {
            if (block == "Player" && collision.gameObject.CompareTag(block))
                collision.gameObject.GetComponent<PlayerBehaviour>().StopMoving();
        }
    }
}
