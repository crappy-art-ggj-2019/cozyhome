using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMurderousIntentOfAStone : MonoBehaviour
{
    public float speed;
    private Transform victim;

    // Start is called before the first frame update
    void Start()
    {
        // target the "Enemy" that was spawned first
        victim = GameObject.FindGameObjectWithTag("Enemy").transform;   // please don't add multiple enemies k thnx bye
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, victim.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == victim)
        {
            // do the killing thing
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
