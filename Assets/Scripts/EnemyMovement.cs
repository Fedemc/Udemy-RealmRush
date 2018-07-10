using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        Debug.Log("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            Debug.Log("Visiting: " + waypoint.transform.position.x + "," + waypoint.transform.position.z);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("Ending patrol");
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
