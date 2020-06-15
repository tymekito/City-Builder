using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text dayText;
    [SerializeField]
    private TMP_Text cityText;
    private CityController city;
    private void Start()
    {
        city = gameObject.GetComponent<CityController>();
    }
    public void UpdateDayCount()
    {
        dayText.text = string.Format("Day {0}", city.Day.ToString());
    }
    public void UpdateCityData()
    {

      cityText.text=string.Format
            ("Jobs: {0}/{1}\nCash: ${2} (+${6})\nPopulation: {3}/{4}\nFood: {5}",
            (int)city.JobsCurrent, 
            (int)city.JobsCeiling, 
            (int)city.Cash, 
            (int)city.PopulationCurrent, 
            (int)city.PopulationCeiling, 
            (int)city.Food,
            (int)city.JobsCurrent*2);
    
    }

}
