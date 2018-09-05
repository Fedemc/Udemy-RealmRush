using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float movementPeriod = .5f;
    private Waypoint targetWaypoint;
    [SerializeField] ParticleSystem enemyGoalParticles;
    private Transform enemyGoalParticlesParent;


   
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
        enemyGoalParticlesParent = GameObject.Find("DeathFXs").transform;
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        //Debug.Log("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            //Move
            //transform.position = waypoint.transform.position;
            targetWaypoint = waypoint;
            yield return new WaitForSeconds(movementPeriod);
        }
        //Debug.Log("Goal reached");
        MovementFinished();
    }

    private void MovementFinished()
    {
        var vfx = Instantiate(enemyGoalParticles, transform.position, Quaternion.identity);
        vfx.transform.parent = enemyGoalParticlesParent;
        vfx.Play();
        float vfxDelay = vfx.main.duration;
        Destroy(vfx.gameObject, vfxDelay);
        Destroy(gameObject);
    }

    void Update ()
    {
        float moveTime = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.transform.position, moveTime);
    }

}
