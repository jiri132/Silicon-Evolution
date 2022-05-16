using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragger : MonoBehaviour
{
    [SerializeField]private EvolutionManager manager, other;
    [SerializeField]private bool canCombine;
    [SerializeField] private float speed;
    [SerializeField] private GameObject particles, evolutionPrefab;

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (canCombine)
        {
            //other = null;
            canCombine = false;
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
            StartCoroutine( CombineAnimation());
            canCombine = false;
        }
    }

    IEnumerator CombineAnimation()
    {
        //variables needed
        Vector3 pos1 = manager.gameObject.transform.position;
        Vector3 pos2 = other.gameObject.transform.position;
        Vector3 middlePos = pos1 + (pos1 - pos2);
        int ID = manager.evolution_ID + 1;
        //lerp them to the correct position
        while (manager.gameObject.transform.position != middlePos  && other.gameObject.transform.position != middlePos)
        {
            manager.gameObject.transform.position = Vector3.Slerp(pos1, middlePos, speed * Time.deltaTime);
            other.gameObject.transform.position = Vector3.Slerp(pos2, middlePos, speed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        //spawn particle
        Instantiate(particles,middlePos,Quaternion.identity);
        //set the object his data and spawn it
        
        Debug.Log(other);

        //spawning and setting the correct ID
        GameObject a = Instantiate(evolutionPrefab, middlePos, Quaternion.identity);
        EvolutionManager e = a.GetComponent<EvolutionManager>();
        e.evolution_ID = ID;
        e.SetImage();

        //destroy the old objects
        Destroy(manager.gameObject);
        Destroy(other.gameObject);

        yield return new WaitForSeconds(0.1f);
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
