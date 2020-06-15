using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

enum state
{
    build,
    sell
}
public class BuildingHandler : MonoBehaviour
{
    [SerializeField]
    private CityController city;
    [SerializeField]
    private UIController uIController;
    [SerializeField]
    private BuildingController[] buildings;
    [SerializeField]
    private BoardController board;
    private BuildingController selectedBuilding;

    private void Update()
    {
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftShift) && selectedBuilding!=null)
        {
            InteractWithBoard(state.build);
        }
        if(Input.GetMouseButtonDown(1)&&selectedBuilding !=null)
        {
            InteractWithBoard(state.build);
        }
        if(Input.GetMouseButtonDown(1)&& Input.GetKey(KeyCode.S))
        {
            InteractWithBoard(state.sell);
        }
    }
    /// <summary>
    /// what happend when interact with board
    /// </summary>
    /// <param name="action"> action id 0 build 1 sell</param>
    void InteractWithBoard(state action)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;// out param
        if(Physics.Raycast(ray,out hit))
        {
            Vector3 gridPos = board.CalculateGridPosition(hit.point);
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (action.Equals(state.build) && board.CheckForBuildingAtPosition(gridPos) == null)
                {
                    // build building
                    if (city.Cash >= selectedBuilding.cost)
                    {
                        // check cash
                        city.DepositCash(-selectedBuilding.cost);
                        uIController.UpdateCityData();
                        city.buildingCounts[selectedBuilding.id]++;
                        board.AddBuilding(selectedBuilding, gridPos);
                    }
                }
                else if(action.Equals(state.sell) && board.CheckForBuildingAtPosition(gridPos) != null)
                {
                    // if building on pos is not null
                    city.DepositCash(board.CheckForBuildingAtPosition(gridPos).cost/2);
                    // refund half of value
                    board.RemoveBuilding(gridPos);
                    uIController.UpdateCityData();
                }
            }
        }
    }
    public void EnableBuilder(int building)
    {
        selectedBuilding = buildings[building];
       // Debug.Log("Selected building: " + selectedBuilding.name);
    }
}
