using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    [SerializeField] Transform targetEnemy;

    private void Update()
    {
        SetTargetEnemy();
        if (targetEnemy == null)
        {
            Shoot(false);
            return;
        }
        objectToPan.LookAt(targetEnemy);
        FireAtEnemy();
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (var testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform closestEnemy, Transform testEnemy)
    {
        var distToA = Vector3.Distance(transform.position, closestEnemy.position);
        var distToB = Vector3.Distance(transform.position, testEnemy.position);

        return distToA < distToB ? closestEnemy : testEnemy;
    }

    void FireAtEnemy()
    {
        float distance = Vector3.Distance(targetEnemy.position, transform.position);
        if (distance <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool toggle)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = toggle;
    }
}
