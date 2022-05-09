using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector2 screenSize;
    [SerializeField] private Vector2 offset;
    [SerializeField] private GameObject obj;


    //CHANGE THIS if you want a faster spawning
    public float waitingSeconds;

    //start the coroutine with the settings of screen size and offset
    private void Start()
    {
        screenSize = GetScreenSize();
        StartCoroutine(SpawnObjectsInsideArea(screenSize, offset));
    }

    //infinite loop that calls it self for spawning objects
    IEnumerator SpawnObjectsInsideArea(Vector2 Area, Vector2 offset)
    {
        while(true)
        {
            //allocte the space where it can spawn
            Vector2 min = -screenSize + offset;
            Vector2 max = screenSize - offset;
            Vector2 randomPos = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //spawn the object
            Instantiate(obj,randomPos, Quaternion.identity);

            //wait for the total amount of seconds
            yield return new WaitForSecondsRealtime(waitingSeconds);
        }
    }
    //get the screen size 
    public Vector2 GetScreenSize()
    {
        //get camera to locate it easyer in pixesl
        Camera cam = Camera.main;
        float pw = cam.pixelWidth;
        float ph = cam.pixelHeight;

        //reutrn vector2 that oconverts pixels to units
        return Camera.main.ScreenToWorldPoint(new Vector2(pw, ph));
    }
}
