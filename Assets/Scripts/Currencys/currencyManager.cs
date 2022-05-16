using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class currencyManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currency;
    public static float usdAmount;
    public static float dogecoinAmount;
    public static float cardanoAmount;
    public static float etheriumAmount;
    public static float bitcoinAmount;
    private bool loop = true;

    private void Start()
    {
        StartCoroutine(Checker());
    }

    // In de scene, zoek naar alle objecten en geef geld gebaseerd op de ID van ieder object, doe dit iedere seconde
    IEnumerator Checker()
    {
        while(loop == true)
        {
            currency.text = "Dogecoin: " + dogecoinAmount;
            yield return new WaitForSeconds(1f);
            GameObject[] currencyGivers = GameObject.FindGameObjectsWithTag("Currency");

            foreach (GameObject giver in currencyGivers)
            {
                EvolutionManager evoScript;
                evoScript = (EvolutionManager)GameObject.Find(giver.name).GetComponent(typeof(EvolutionManager));
                evoScript.Transfer();
            }
        }
    }
}
