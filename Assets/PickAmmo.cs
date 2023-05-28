using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAmmo : MonoBehaviour
{
    public WeaponAmmo weaponAmmo;

    private void Start()
    {
        weaponAmmo = GameObject.Find("ARMA1").GetComponent<WeaponAmmo>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (weaponAmmo.isActiveAndEnabled == true && other.tag == "Player")
        {
            weaponAmmo.currentAmmo = weaponAmmo.currentAmmo + 10;
            Destroy(gameObject, 0.1f);
        }
    }
}
