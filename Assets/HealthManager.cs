using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int healthSize = 100;
    [SerializeField] public int currentHealth;

    void Start()
    {
        currentHealth = healthSize;
    }

    public void RestoreHealth(int healing)
    {
        if (healing >= healthSize - currentHealth)
        {
            currentHealth = 100;
        }
        else if (healing < healthSize - currentHealth)
        {
            currentHealth = currentHealth + healing;
        }
    }

    public void DamagePlayer(int damage)
    {
        if (damage >= currentHealth)
        {
            //SceneManager.LoadScene("Death", LoadSceneMode.Single);
            //Destroy(this, 1);
        }
        else
        {
            currentHealth = currentHealth - damage;
        }
    }
}
