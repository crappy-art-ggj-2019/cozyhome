﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CowmanAIScript : MonoBehaviour
{
    [Inject]
    public GameManagerScript gmc;

    float[] direction;
    private Rigidbody2D ourRigidbody2D;
    [SerializeField] float prefdist, distancetogoal;
    
    // Start is called before the first frame update
    void Start()
    {
        direction = new float[2];
        ourRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void randomizeDirection()
    {
        direction[0] = Random.Range(-10f, 10f);
        direction[1] = Random.Range(-10f, 10f);
    }
    
    // Update is called once per frame
    void Update()
    {
        //store previous distance.
        prefdist = distancetogoal;

        
        if (ourRigidbody2D.velocity == Vector2.zero)
        {
            

        }
        randomizeDirection();

        distancetogoal = Vector2.Distance(transform.position, Vector2.zero);
        if (distancetogoal > prefdist)
        {
            ourRigidbody2D.velocity = Vector2.MoveTowards(transform.position, Vector2.zero, 10f);
        }
        else
        { ourRigidbody2D.velocity = new Vector2(direction[0], direction[1]); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Defender" || collision.gameObject.tag == "Attacker")
        {
            gmc.OnAvatarGet();
        }
    }
}
