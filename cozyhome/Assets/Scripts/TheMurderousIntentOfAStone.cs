using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMurderousIntentOfAStone : MonoBehaviour
{
    public float speed;
    public string nameOnTheBullet;

    private Transform victim;
    [SerializeField] private int damage;
    [SerializeField] private GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        // target the "Enemy" that was spawned first
        victim = GameObject.Find(nameOnTheBullet).transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, victim.position, speed * Time.deltaTime);
    }
    public void setOrigin(GameObject originator)
    {
        Debug.Log("originator: " + originator.name);
        origin = originator;
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
