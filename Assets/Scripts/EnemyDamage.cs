using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints -= 1;
        hitParticlePrefab.Play();
    }

    public void KillEnemy(ParticleSystem particleEffect = null)
    {
        ParticleSystem vfx;
        if (particleEffect == null)
        {
            vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        }
        else
        {
            vfx = Instantiate(particleEffect, transform.position, Quaternion.identity);
        }
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
