using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragger : MonoBehaviour
{
    [SerializeField]private EvolutionManager manager, other;
    [SerializeField] private bool canCombine, animated;
    [SerializeField] private float speed;
    [SerializeField] private GameObject particles, evolutionPrefab;
    public List<GameObject> touchingObjects = new List<GameObject>();

    // Start is called before the first frame update
    private bool isDragging;

    private void Start()
    {
        manager = GetComponent<EvolutionManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchingObjects.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchingObjects.Remove(collision.gameObject);
    }
    public void OnMouseDown()
    {
        isDragging = true;
    }
    public void OnMouseUp()
    {
        if (gameObject != null)
        {
            isDragging = false;
            foreach (GameObject obj in touchingObjects)
            {
                other = obj.GetComponent<EvolutionManager>();

                if (other.evolution_ID == manager.evolution_ID)
                {
                    touchingObjects.Clear();
                    if (animated) { StartCoroutine(CombineAnimation()); }
                    else { Combine(); }

                    AudioManager.PlaySFX(AudioManager.sfxC[0].clip);

                    canCombine = false;
                    break;
                }

            }
        }
    }
    void Combine()
    {
        Vector3 pos1 = manager.gameObject.transform.position;
        Vector3 pos2 = other.gameObject.transform.position;
        Vector3 middlePos = pos1 + (pos1 - pos2);
        int ID = manager.evolution_ID + 1;

        //spawn particle
        Instantiate(particles, middlePos, Quaternion.identity);
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
