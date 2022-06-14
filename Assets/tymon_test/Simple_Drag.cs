using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_Drag : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isDargged;
    public void OnMouseDown()
    {
        isDargged = true;
    }
    public void OnMouseUp()
    {
        isDargged = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(isDargged == true)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos); 
        }   
    }
}
