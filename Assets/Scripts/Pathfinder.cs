using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint StartWaypoint, EndWaypoint;
    
    void Start ()
    {
        LoadBlocks();
        ColorStartAndEnd();
	}

    private void ColorStartAndEnd()
    {
        StartWaypoint.SetTopColor(Color.green);
        EndWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();
            bool isOverlapping = grid.ContainsKey(gridPos);
            if(isOverlapping)
            {
                Debug.LogWarning("Overlapping block." + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }

        print("Loaded " + grid.Count + " blocks");
        
    }
}
