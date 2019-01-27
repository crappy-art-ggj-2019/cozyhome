using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public List<string> blocks;
    private Collider2D ourCollider;
    AudioClip bump;
    [SerializeField] private int health = 100;
    [SerializeField] bool newhit=true;
    [SerializeField] ParticleSystem pspref;
    // Start is called before the first frame update
    void Start()
    {
        ourCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if health is 0 destroy object, if not, check if attacker is not already attacking. Then remove 10 points.
        if (health < 1) { breaking(); } else { if (newhit == true&&collision.gameObject.tag=="Attacker") { health -= 10;newhit = false;  } }
        foreach (string block in blocks)
        {
            // if not supposed to block
            if (!blocks.Contains(collision.gameObject.name))
                // ignore this specific collision
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), ourCollider);
            
            // if it's a player and supposed to block
            if (collision.gameObject.GetComponent<PlayerBehaviour>() != null && collision.gameObject.name == block)
                // call its "StopMoving" function to make it stop moving
                collision.gameObject.GetComponent<PlayerBehaviour>().StopMoving();
            //bump = Resources.Load<AudioClip>("footstep00");
            //AudioSource audioSrc = new AudioSource();
            //audioSrc.PlayOneShot(bump, 1f);
            AudioSource.PlayClipAtPoint(bump, new Vector3(0, 0, 0));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        newhit = true;
    }
    private void breaking()
    {
        Instantiate(pspref, transform);
        Destroy(gameObject);
    }
}
