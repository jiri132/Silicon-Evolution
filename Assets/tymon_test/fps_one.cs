using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps_one : MonoBehaviour
{
    public int targetFrameRate = 1;
    private void OnMouseDown()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
