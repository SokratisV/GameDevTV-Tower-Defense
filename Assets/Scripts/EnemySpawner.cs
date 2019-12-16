using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 10f)] float secondsBetweenSpawns;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParent;
    [SerializeField] TextMeshProUGUI enemiesText;
    [SerializeField] AudioClip spawnEnemySFX;
    int score = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        enemiesText.text = "0";
    }

    private IEnumerator SpawnEnemies()
    {
        EnemyMovement enemyMovement;
        AudioSource audio = GetComponent<AudioSource>();
        while (true)
        {
            enemyMovement = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            audio.PlayOneShot(spawnEnemySFX);
            IncreaseScore();
            enemyMovement.transform.parent = enemyParent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void IncreaseScore()
    {
        score++;
        enemiesText.text = score.ToString();
    }
}
