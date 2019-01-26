using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAIScript : MonoBehaviour
{
    float[] direction;
    private Rigidbody2D ourRigidbody2D;
    private GameManagerScript gmc;

    // Start is called before the first frame update
    void Start()
    {
        direction = new float[2];
        ourRigidbody2D = GetComponent<Rigidbody2D>();
        gmc = GameObject.Find("/GameManagerController").GetComponent<GameManagerScript>();
    }

    void randomizeDirection()
    {
        direction[0] = Random.Range(-10f, 10f);
        direction[1] = Random.Range(-10f, 10f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (ourRigidbody2D.velocity == Vector2.zero)
        {
            randomizeDirection();
            
        }
        ourRigidbody2D.velocity = new Vector2(direction[0], direction[1]);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Defender" || collision.gameObject.tag == "Attacker")
        {
            gmc.OnAvatarGet();
        }
    }
}
