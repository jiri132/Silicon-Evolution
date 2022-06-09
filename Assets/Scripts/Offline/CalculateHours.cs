using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateHours : MonoBehaviour
{

    [SerializeField]private int days, months, years;
    [SerializeField]private int hours, minutes,seconds;
    private int[] monthsDateLength = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    private void OnApplicationQuit()
    {
        //setting the variables
        years = System.DateTime.Now.Year;
        months = System.DateTime.Now.Month;
        days = System.DateTime.Now.Day;

        hours = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;


        //get time and date save to playerprefs
        SaveLoad(false);
    }

    private void Awake()
    {
        //loading in the data
        SaveLoad(true);

        //making then ew variables
        int newdays, newmonths, newyears;
        int newhours, newminutes, newseconds;

        //new variables setting
        newyears = System.DateTime.Now.Year;
        newmonths = System.DateTime.Now.Month;
        newdays = System.DateTime.Now.Day;

        newhours = System.DateTime.Now.Hour;
        newminutes = System.DateTime.Now.Minute;
        newseconds = System.DateTime.Now.Second;

        //calculating time difference
        newyears -= years;
        if (newyears > 0) { newmonths += newyears * 12; }
        newmonths -= months;
        if (newmonths > 0) { for (int i = 0; i < months; i++) { newdays += monthsDateLength[months+i]; } }
        newdays -= days;
        if (newdays > 0) { newhours += newdays * 24; }
        newhours -= hours;
        if (newhours > 0) { newminutes += newhours * 60; }
        newminutes -= minutes;
        if (newminutes > 0) { newseconds += newminutes * 60; }
        newseconds -= seconds;
        Debug.Log($"Total seconds away: [{newseconds}]");


}

    void SaveLoad(bool load)
    {
        switch (load)
        {
            case true:
                years = PlayerPrefs.GetInt("years");
                months =  PlayerPrefs.GetInt("months");
                days = PlayerPrefs.GetInt("days");
                hours = PlayerPrefs.GetInt("hours");
                minutes = PlayerPrefs.GetInt("minutes");

                break;
            case false:
                PlayerPrefs.SetInt("years", years);
                PlayerPrefs.SetInt("months", months);
                PlayerPrefs.SetInt("days", days);
                PlayerPrefs.SetInt("hours", hours);
                PlayerPrefs.SetInt("minutes", minutes);

                break;

        }
    }

}
