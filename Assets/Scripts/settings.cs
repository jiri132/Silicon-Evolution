using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour
{
    public GameObject pase;
    public bool settings_en;
    // Start is called before the first frame update
    public GameObject enable_set;
    public int thirty_fps = 30, sixty_fps = 60, ninety_fps = 90, hunder_fps = 120;
    public int targetFrameRate;
    //this is for the button
    public void sett_en_dis()
    {
        settings_en = !settings_en;
    }
    void Start()
    {
        settings_en = true;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
    //Settings enabler
    private void OnMouseDown()
    {

        if (settings_en == true)
        {
            enable_set.SetActive(true);
            settings_en = false;
        }else if(settings_en == false)
        {
            enable_set.SetActive(false);
            settings_en = true;
        }


    }
    // Update is called once per frame
    void Update()
    {


    }
}
