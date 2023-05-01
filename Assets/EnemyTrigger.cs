using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.colD = true;
        }
    }
}
