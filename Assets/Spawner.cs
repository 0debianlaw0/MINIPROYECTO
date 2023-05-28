using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Enemigo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTenSeconds());
    }

    IEnumerator SpawnTenSeconds()
    {
        Instantiate(Enemigo, transform.position, Enemigo.transform.rotation);
        yield return new WaitForSeconds(10);
        StartCoroutine(SpawnTenSeconds());
    }
}
