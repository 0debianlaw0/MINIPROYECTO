using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAmmo : MonoBehaviour
{
    public WeaponAmmo weaponAmmo;
    public WeaponAmmo weaponAmmo2;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (weaponAmmo.isActiveAndEnabled == true)
        {
            weaponAmmo.currentAmmo = weaponAmmo.currentAmmo + 10;
            Destroy(gameObject);
        }
        if (weaponAmmo2.isActiveAndEnabled == true)
        {
            weaponAmmo2.currentAmmo = weaponAmmo2.currentAmmo + 10;
            Destroy(gameObject);
        }
    }
}
