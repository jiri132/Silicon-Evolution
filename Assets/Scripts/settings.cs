using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour
{
    public GameObject pase;
    public bool settings_en;
    // Start is called before the first frame update
    public GameObject enable_set;

    //this is for the button
    public void sett_en_dis()
    {
        settings_en = !settings_en;
    }
    void Start()
    {
        
    }
    private void OnMouseDown()
    {


        if(settings_en == false)
        {
            enable_set.SetActive(false);
            settings_en = true;
        }
        if (settings_en == true)
        {
            enable_set.SetActive(true);

        }
    }
    // Update is called once per frame
    void Update()
    {


    }
}
