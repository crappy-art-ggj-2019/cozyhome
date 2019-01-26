using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionFlipper : MonoBehaviour
{

    Vector2 lastLocation;
    SpriteRenderer spriteRenderer;
    float sinceChanged = 0.0f;
    float delaySince = 0.5f;
    bool directionLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        lastLocation = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentLocation = this.transform.position;
        float xDirection = currentLocation.x - lastLocation.x;

        Debug.Log(sinceChanged + "-" + Time.time);
        Debug.Log(sinceChanged < Time.time);
        if (sinceChanged < Time.time)
        {
            if (directionLeft && xDirection > 0) FlipDirection(false);
            else if (!directionLeft && xDirection < 0) FlipDirection(true);
        }

        lastLocation = this.transform.position;
    }

    void FlipDirection(bool directionLeftChange)
    {
        spriteRenderer.flipX = directionLeftChange;
        directionLeft = directionLeftChange;
        sinceChanged = Time.time + delaySince;
    }
}
