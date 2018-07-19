using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Waypoint StartWaypoint, EndWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    
    void Start ()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbours();
	}

    private void ExploreNeighbours()
    {
        foreach (Vector2Int dir in directions)
        {
            Vector2Int explorationCoordinates = StartWaypoint.GetGridPos() + dir;
            print("Exploring " + explorationCoordinates);
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch
            {
                print("Missing key..." + explorationCoordinates + " skipping");
            }
        }
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
