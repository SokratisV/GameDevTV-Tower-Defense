using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] int damageToPlayer = 1;
    [SerializeField] ParticleSystem selfDestructParticles;
    private void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        StartCoroutine(FollowPath(pathfinder.GetPath()));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        GetComponentInParent<EnemyDamage>().KillEnemy(selfDestructParticles);
        FindObjectOfType<PlayerHealth>().ReduceHealth(damageToPlayer);
    }
}
