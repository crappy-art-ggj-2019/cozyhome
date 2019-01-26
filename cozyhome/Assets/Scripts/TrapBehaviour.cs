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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (targets.Contains(collision.gameObject.tag))
        {
            print("KILL! MUST KILL!");

            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
