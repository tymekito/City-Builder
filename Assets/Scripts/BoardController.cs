using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    private BuildingController[,] buildings = new BuildingController[100, 100];
    public void AddBuilding(BuildingController building, Vector3 position)
    {
        buildings[(int)position.x, (int)position.z] = Instantiate(building, position,Quaternion.Euler(0,180,0)); // object rotation that the object has
    }
    public BuildingController CheckForBuildingAtPosition(Vector3 position)
    {
        return buildings[(int)position.x, (int)position.z];
        // check cell
    }
    public Vector3 CalculateGridPosition(Vector3 position)
    {
        return new Vector3(Mathf.Round( position.x),.5f,Mathf.Round(position.z));
    }
    public void RemoveBuilding(Vector3 pos)
    {
        Destroy(buildings[(int)pos.x, (int)pos.z].gameObject);
        buildings[(int)pos.x, (int)pos.z]=null;
    }
}
