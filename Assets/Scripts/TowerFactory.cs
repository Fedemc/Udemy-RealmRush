using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit;
    [SerializeField] Tower[] towerPrefabs;
    private int towerCount=0;

    public void AddTower(Waypoint baseWaypoint)
    {
        if(towerCount<=towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            Debug.Log("Already at max towers");
        }
        
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var tower = Instantiate(pickRandomTower(), baseWaypoint.transform.position, Quaternion.identity);
        tower.transform.parent = GameObject.Find("Towers").transform;
        baseWaypoint.isPlaceable = false;
        towerCount++;
    }

    private Tower pickRandomTower()
    {
        return towerPrefabs[Random.Range(0, towerPrefabs.Length)];
    }   
}
