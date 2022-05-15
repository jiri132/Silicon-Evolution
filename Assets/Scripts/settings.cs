using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour
{
    public GameObject pase;
    public bool settings_en;
    // Start is called before the first frame update


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
        settings_en = true;
        if (settings_en == true)
        {
            Instantiate(pase, new Vector3(0, 0, 0), Quaternion.identity);
            settings_en = false;
        }        
    }
    // Update is called once per frame
    void Update()
    {


    }
}
