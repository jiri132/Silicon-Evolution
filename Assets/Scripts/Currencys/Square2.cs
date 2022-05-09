using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square2 : MonoBehaviour
{
    void Update()
    {
        Currency.currencyAmount = Currency.currencyAmount + 2 * Time.deltaTime;
    }
}
