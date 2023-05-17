using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int healthSize = 100;
    [SerializeField] public int currentHealth;
    public string escenaMuerte;

    void Start()
    {
        currentHealth = healthSize;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject, 1);
            SceneManager.LoadScene(escenaMuerte, LoadSceneMode.Single);
        }
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
            Destroy(gameObject, 1);
            SceneManager.LoadScene(escenaMuerte, LoadSceneMode.Single);
        }
        else
        {
            currentHealth = currentHealth - damage;
        }
    }
}
