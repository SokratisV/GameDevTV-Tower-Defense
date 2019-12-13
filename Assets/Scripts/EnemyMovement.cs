using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private void Start()
    {
        // StartCoroutine(FollowPath());
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        StartCoroutine(FollowPath(pathfinder.GetPath()));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
