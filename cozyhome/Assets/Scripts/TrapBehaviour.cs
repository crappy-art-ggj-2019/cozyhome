using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "monster")
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
