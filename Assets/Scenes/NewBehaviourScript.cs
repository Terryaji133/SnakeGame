using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        Resolution currentResolution = Screen.currentResolution;

       
        int windowWidth = Screen.width;
        int windowHeight = Screen.height;

        
        Debug.Log("¤j¤p: " + windowWidth + "x" + windowHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
