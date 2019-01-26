using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    public List<string> targets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targets.Contains(collision.tag))
        {
            print("KILL! MUST KILL!");

            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
