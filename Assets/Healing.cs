using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public HealthManager healthManager;

    private void Start()
    {
        healthManager = GameObject.Find("Player").GetComponent<HealthManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (healthManager.currentHealth <= 90)
            {
                healthManager.currentHealth = healthManager.currentHealth + 10;
                Destroy(gameObject);
            }
        }
    }
}
