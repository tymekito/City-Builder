using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
    public int Cash { get; set; }
    public int Day { get; set; }
    public float PopulationCurrent { get; set; }
    public float PopulationCeiling { get; set; }
    public int JobsCurrent { get; set; }
    public int JobsCeiling { get; set; }
    public float Food { get; set; }

    public int[] buildingCounts = new int [4];
    // 0 houses
    // 1 farms 
    // 2 factories
    public int startCash;
    private UIController uIController;

    private void Start()
    {
        uIController = GetComponent<UIController>();
        Cash = startCash;
    }
    public void EndTurn()
    {
        Day++;
        CalculateCash();
        CalculatePopulation();
        CalculateJobs();
        CalculateFood();
        uIController.UpdateCityData();
        uIController.UpdateDayCount();
      /*  Debug.LogFormat(
            "Jobs: {0}/{1}, Cash: {2}, Pop: {3}/{4}, Food: {5}",
            JobsCurrent,JobsCeiling,Cash,PopulationCurrent,PopulationCeiling,Food);
        */
    }
    void CalculateJobs()
    {
        // every factory gives 10 jobs units
        JobsCeiling = buildingCounts[3] * 10;
        JobsCurrent = Mathf.Min((int)PopulationCurrent,JobsCeiling);
        
    }
    void CalculateCash()
    {
        Cash += JobsCurrent * 2;//every jobs gives 2 units of cash
    }
    void CalculateFood()
    {
        // every farms gives 2 units of food
        Food += buildingCounts[2] * 2f;
    }
    void CalculatePopulation()
    {
        PopulationCeiling = buildingCounts[1] * 5;// house gives 5 people
        if(Food>=PopulationCurrent&&PopulationCurrent<PopulationCeiling)
        {
            // people sub food units
            Food -= PopulationCurrent*.2f;// 4 people take 1 unit of food
            // add some people to current population
            PopulationCurrent = Mathf.Min(PopulationCurrent += Food * .2f, PopulationCeiling);
        }
        else if(Food<PopulationCurrent)
        {
            PopulationCurrent -= (PopulationCurrent - Food)*.5f;
            // sub people from population 
        }
    }
    public void DepositCash(int cash)
    {
        Cash += cash;
    }
}

