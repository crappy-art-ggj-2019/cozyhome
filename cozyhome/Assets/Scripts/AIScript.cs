using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    float[] direction;
    
    // Start is called before the first frame update
    void Start()
    {
        direction = new float[2];
        
    }
    void randomizeDirection()
    {
        direction[0] = Random.Range(-10f, 10f);
        direction[1] = Random.Range(-10f, 10f);
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if (GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            randomizeDirection();
            
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction[0], direction[1]);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
