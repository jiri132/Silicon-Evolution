using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currency;
    public static int currencyAmount;

    // Start is called before the first frame update
    void Start()
    {
        currencyAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currency.text = "Currency: " + currencyAmount;
    }
}
