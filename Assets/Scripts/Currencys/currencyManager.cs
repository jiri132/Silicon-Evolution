using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class currencyManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currency;
    public GameObject[] currencyGivers;
    public EvolutionManager evoScript;
    public static float usdAmount;
    public static float dogecoinAmount;
    public static float cardanoAmount;
    public static float etheriumAmount;
    public static float bitcoinAmount;

    private void Start()
    {
        StartCoroutine(Checker());
    }

    // In de scene, zoek naar alle objecten en geef geld gebaseerd op de ID van ieder object, doe dit iedere seconde
    IEnumerator Checker()
    {
        yield return new WaitForSeconds(1f);
        currencyGivers = GameObject.FindGameObjectsWithTag("Currency");

        foreach (GameObject giver in currencyGivers)
        {
            evoScript = (EvolutionManager)GameObject.Find(giver.name).GetComponent(typeof(EvolutionManager));
            evoScript.Transfer();
        }

        currency.text = "Dogecoin: " + dogecoinAmount;
    }
}
