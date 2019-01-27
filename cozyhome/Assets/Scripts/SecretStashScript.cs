using UnityEngine;

public class SecretStashScript : MonoBehaviour
{
    [SerializeField]
    GameObject secretpanel;

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
