using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class currencyManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currency;
    public static float dogecoinAmount;
    public static float cardanoAmount;
    public static float etheriumAmount;
    public static float bitcoinAmount;
    private bool loop = true;

    private void Start()
    {
        // StartCoroutine(Checker());
    }

    private void Update()
    {
        currency.text = "Dogecoin: " + Mathf.Round(dogecoinAmount);

        if (cardanoAmount != 0)
        {
            currency.text += "\n" + "Cardano: " + Mathf.Round(cardanoAmount);
        }
        if (etheriumAmount != 0)
        {
            currency.text += "\n" + "Etherium: " + Mathf.Round(etheriumAmount);
        }
        if (bitcoinAmount != 0)
        {
            currency.text += "\n" + "Bitcoin: " + Mathf.Round(bitcoinAmount);
        }
    }

    // In de scene, zoek naar alle objecten en geef geld gebaseerd op de ID van ieder object, doe dit iedere seconde
    /*
    IEnumerator Checker()
    {
        while(loop == true)
        {
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
    */
}
