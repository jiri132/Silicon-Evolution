using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jesus : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isDragging;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*collision.GetComponent<EvolutionManager>().evolution_ID;*/
    }
    public void OnMouseDown()
    {
        isDragging = true;
    }
    public void OnMouseUp()
    {
        isDragging = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }
    }
}
