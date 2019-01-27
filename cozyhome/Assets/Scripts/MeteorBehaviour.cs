using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MeteorBehaviour : MonoBehaviour
{
    [Inject]
    public GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.OnMeteor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
