using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject armaCorta;
    public GameObject armaLarga;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && armaCorta.activeSelf == false)
        {
            armaLarga.SetActive(false);
            armaCorta.SetActive(true);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && armaLarga.activeSelf == false)
        {
            armaCorta.SetActive(false);
            armaLarga.SetActive(true);
        }
    }
}
