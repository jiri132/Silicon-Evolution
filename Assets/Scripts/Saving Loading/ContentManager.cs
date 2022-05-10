using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManager : MonoBehaviour
{
    #region THE DATA
    [Header("DEBUG REASONS ONLY")]
    [SerializeField]private List<GameObject> evolutions_GameObjects;
    [SerializeField]private List<int> evolution_ID;
    [SerializeField]private int evolution_totalObjects;
    #endregion

    #region Prefab to spawn
    [Header("Needs the prefab of the evolution object filledi!")]
    public GameObject Prefab;
    #endregion

    #region ALL FUNCTIONS
    #region SAVE LOAD FUNCTION
    private void Awake()
    {
        //get all the stored daat back on screen
        LoadWithPlayerPrefs();
        
    }
    private void OnApplicationQuit()
    {
        //getting all the evolution objects
        GetEvolutionObjectData();

        //setting up player prefs
        SaveWithPlayerPrefs();
    }
    #endregion
    #region CUSTOM LOAD FUNCTION
    //loading from player prefs
    private void LoadWithPlayerPrefs()
    {
        //get hte total object to see if we even have to check the rest
        evolution_totalObjects = PlayerPrefs.GetInt("evolution_totalObjects",0);

        //if there aren o objects the just return no computing needed
        if (evolution_totalObjects == 0) { return; }

        //getti nthe ID and position then storing it in the psawn data function
        for (int i = 0; i < evolution_totalObjects; i++)
        {
            int ID = PlayerPrefs.GetInt($"evolution_ID-{i}");
            float x = PlayerPrefs.GetFloat($"evolution_GameObject_X-{i}");
            float y = PlayerPrefs.GetFloat($"evolution_GameObject_Y-{i}");
            float z = PlayerPrefs.GetFloat($"evolution_GameObject_Z-{i}");
            SpawnTheData(ID,x,y,z);
        }
    }
    //instantiating the objects you got from player prefs
    private void SpawnTheData(int ID, float x ,float y, float z)
    {
        //spawning the object then setting all  the corrosponding data of images and ID
        GameObject spawned = Instantiate(Prefab,new Vector3(x,y,z),Quaternion.identity);
        EvolutionManager e_m = spawned.GetComponent<EvolutionManager>();
        e_m.evolution_ID = ID;
        e_m.SetImage();
    }
    #endregion
    #region CUSTOM SAVE FUNCTION
    //save all the data to player rpefs
    private void SaveWithPlayerPrefs()
    {
        //setting the new evolution objects how many there are to compute the other things in a loop
        PlayerPrefs.SetInt("evolution_totalObjects",evolution_totalObjects);

        //setting the XYZ position and ID for every obejct!
        for (int i = 0; i < evolution_totalObjects; i++)
        {
            //ID
            PlayerPrefs.SetInt($"evolution_ID-{i}",evolution_ID[i]);

            //Position
            PlayerPrefs.SetFloat($"evolution_GameObject_X-{i}",evolutions_GameObjects[i].transform.position.x);
            PlayerPrefs.SetFloat($"evolution_GameObject_Y-{i}", evolutions_GameObjects[i].transform.position.y);
            PlayerPrefs.SetFloat($"evolution_GameObject_Z-{i}", evolutions_GameObjects[i].transform.position.z);
        }
    }
    #endregion
    #region CUSTOM GETDATA FUNCTION
    //get all the evolution from the data ready to be made for setting it in player prefs
    private void GetEvolutionObjectData()
    {
        EvolutionManager[] e_m = GameObject.FindObjectsOfType<EvolutionManager>();
        //setting them in the correct order of instances and set the ID numbers alsoo with the smae list dd the count so we can use player prefs
        for (int i = 0; i < e_m.Length; i++)
        {
            evolutions_GameObjects.Add(e_m[i].gameObject);
            evolution_ID.Add(i);
        }
        evolution_totalObjects = evolutions_GameObjects.Count;
    }
    #endregion
    #endregion
}
