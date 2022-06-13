using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mute_music : MonoBehaviour
{
    private bool muted;
    private void OnMouseDown()
    {
        if (muted == true)
        {
            mutee.GetComponent<AudioSource>().mute = true;
            muted = false;
        }
        else if (muted == false)
        {
            mutee.GetComponent<AudioSource>().mute = false;
            muted = true;
        }

    }
    public GameObject mutee;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
