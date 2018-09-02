using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Waypoint StartWaypoint, EndWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter; //current searchCenter

    private List<Waypoint> path= new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if(path.Count==0)
        {
            CalculatePath();
        }

        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        SetAsPath(EndWaypoint);

        Waypoint previous = EndWaypoint.exploredFrom;
        while(previous != StartWaypoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }
        SetAsPath(StartWaypoint);
        path.Reverse();
    }

    private void SetAsPath(Waypoint w)
    {
        path.Add(w);
        w.isPlaceable = false;
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(StartWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }

        //print("Finished pathfinding?");
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == EndWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int dir in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + dir;
            if(grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeigbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeigbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if(neighbour.isExplored || queue.Contains(neighbour))
        {
            //nothing
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
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
    }
}
