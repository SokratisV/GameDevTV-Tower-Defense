using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] AudioClip playerDamageSFX;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    public void ReduceHealth(int amount)
    {
        health -= amount;
        healthText.text = health.ToString();
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        if (health <= 0)
        {
            //dead
        }
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
    }
}
