﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementSpeed = 5;
    float maxDistance = 30f;
    GameManagerScript gmc;
    // where to move to
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        // stop player from moving to 0,0 by default
        targetPosition = transform.position;

        gmc = GameObject.Find("/GameManagerController").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {    //this can be improved by taking the barheight.
        Debug.Log("X: "+Input.mousePosition.y+ " minpos: " + -(Screen.width/Screen.height) / 2 + 50);
        //Debug.Log();
        // only follow set the targetPosition when the user clicks
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.y >= -(Screen.width / Screen.height) / 2 + 50) 
        {
            
            // set targetPosition to the mouseposition relative to the screen
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // player must not move in 3D!!
            targetPosition.z = 0;
        }
        checkwinstate();
        if (transform.position != targetPosition)
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

    public void StopMoving()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        targetPosition = transform.position;
    }
    private void checkwinstate()
    {
        // what is the distance to the center. The closer you get, the more close you are to winning
        float distance = Vector2.Distance(transform.position, Vector2.zero);
        
        Debug.Log(distance);
        gmc.OnMoveCloser(1-distance/maxDistance);
    }
}
