using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementSpeed = 5;

    // where to move to
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        // stop player from moving to 0,0 by default
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // only follow set the targetPosition when the user clicks
        if (Input.GetMouseButtonDown(0))
        {
            // set targetPosition to the mouseposition relative to the screen
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // player must not move in 3D!!
            targetPosition.z = 0;
        }

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

    }
}
