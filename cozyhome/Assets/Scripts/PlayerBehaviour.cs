using UnityEngine;
using Zenject;

public class PlayerBehaviour : MonoBehaviour
{
    [Inject]
    public GameManagerScript gmc;

    public float movementSpeed = 5;
    float maxDistance = 30f;
    
    // where to move to
    private Vector3 targetPosition;
  
    AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        // stop player from moving to 0,0 by default
        targetPosition = transform.position;
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        checkwinstate();
        movePlayer();
        //this can be improved by taking the barheight.
        //Debug.Log("X: "+Input.mousePosition.y+ " minpos: " + -(Screen.width/Screen.height) / 2 + 50);
        //Debug.Log();
        //print(Input.mousePosition.y >= Screen.height * 144 / 720);
        // only follow set the targetPosition when the user clicks
        
    }
    public void movePlayer()
    {
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.y >= Screen.height * 144 / 720)
        {
            // set targetPosition to the mouseposition relative to the screen
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // player must not move in 3D!!
            targetPosition.z = 0;
        }

        if (transform.position != targetPosition)
        {
            playwalksound(true);
                
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        }
        else
        {
            playwalksound(false);
        }
            
    }
    private void playwalksound(bool state)
    {
        if (state) { if (!audioSrc.isPlaying) { audioSrc.Play(); } }
        else { audioSrc.Stop(); }
    }
    public void StopMoving()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        targetPosition = transform.position;
    }
    private void checkwinstate()
    {
        // what is the distance to the center. The closer you get, the more close you are to winning
        float distance = Vector2.Distance(transform.position, Vector2.zero);
        gmc.OnMoveCloser(1 - distance / maxDistance);
    }
}
