using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMeasurement : MonoBehaviour
{

    Vector2 lastLocation;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        lastLocation = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentLocation = this.transform.position;
        float speed = Vector2.Distance(currentLocation, lastLocation);

        animator.SetFloat("Speed", speed);

        Debug.Log(speed);

        lastLocation = this.transform.position;
    }
}
