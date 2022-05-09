using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square1 : MonoBehaviour
{
    void Update()
    {
        Currency.currencyAmount = Currency.currencyAmount + 1 * Time.deltaTime;
    }
}
