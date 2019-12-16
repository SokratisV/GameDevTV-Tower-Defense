using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyDeathSFX;
    [SerializeField] AudioClip enemyHitSFX;
    AudioSource m_audio;
    Vector3 camPos;

    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
        camPos = Camera.main.transform.position;
    }

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
        m_audio.PlayOneShot(enemyHitSFX);
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
        AudioSource.PlayClipAtPoint(enemyDeathSFX, camPos, .5f);
        Destroy(gameObject);
    }
}
