﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    private Waypoint targetWaypoint;

    // Use this for initialization
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        //Debug.Log("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            //Move
            //transform.position = waypoint.transform.position;
            targetWaypoint = waypoint;
            yield return new WaitForSeconds(1f);
        }

        //Debug.Log("Ending patrol");
    }

    void Update ()
    {
        float moveTime = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.transform.position, moveTime);
    }


}
