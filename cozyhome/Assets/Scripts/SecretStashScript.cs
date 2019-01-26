using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretStashScript : MonoBehaviour
{
    [SerializeField]
    GameObject secretpanel;
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
        Debug.Log("Someone Found the stash");
        if (collision.tag == "Attacker")
        {
            Debug.Log("Player found the stash");
            secretpanel.SetActive(true);
        }
    }
}
