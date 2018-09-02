using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit;
    [SerializeField] Tower[] towerPrefabs;
    private int towerCount=0;
    private Queue<Tower> towers = new Queue<Tower>();
    private Transform towerParent;

    private void Start()
    {
        towerParent= GameObject.Find("Towers").transform;
    }

    public void AddTower(Waypoint baseWaypoint)
    {
        if(towers.Count < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }

    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        Tower movedTower = towers.Dequeue();
        movedTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;
        movedTower.transform.position = newBaseWaypoint.transform.position;
        movedTower.baseWaypoint = newBaseWaypoint;
        towers.Enqueue(movedTower);
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var tower = Instantiate(pickRandomTower(), baseWaypoint.transform.position, Quaternion.identity);
        tower.transform.parent = towerParent.transform;
        tower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        towers.Enqueue(tower);
    }

    private Tower pickRandomTower()
    {
        return towerPrefabs[Random.Range(0, towerPrefabs.Length)];
    }   
}
