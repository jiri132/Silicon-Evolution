using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragger : MonoBehaviour
{
    [SerializeField]private EvolutionManager manager, other;
    [SerializeField]private bool canCombine;
    // Start is called before the first frame update
    private bool isDragging;
    private void Start()
    {
        manager = GetComponent<EvolutionManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        other = collision.GetComponent<EvolutionManager>();
      if ( other.evolution_ID == manager.evolution_ID)
        {
            canCombine = true;
            
        }
    }
    public void OnMouseDown()
    {
        isDragging = true;
    }
    public void OnMouseUp()
    {
        isDragging = false;
        if (canCombine)
        {
            manager.Combine();
            Destroy(other.gameObject);
            canCombine = false;
        }
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
