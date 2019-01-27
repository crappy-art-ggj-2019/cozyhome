using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SecretPanelScript : MonoBehaviour
{
    [Inject]
    public SceneLoaderScript sl;

    public void GoodEnding()
    {
        sl.LoadSecretLevel();
    }
    
    public void BadEnding()
    {
        sl.LoadSecretBLevel();
    }
}
