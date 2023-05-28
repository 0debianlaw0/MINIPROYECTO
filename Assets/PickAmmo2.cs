using UnityEngine;

public class PickAmmo2 : MonoBehaviour
{
    public WeaponAmmo weaponAmmo2;

    private void Start()
    {
        weaponAmmo2 = GameObject.Find("ARMA2").GetComponent<WeaponAmmo>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (weaponAmmo2.isActiveAndEnabled == true && other.tag == "Player")
        {
            weaponAmmo2.currentAmmo = weaponAmmo2.currentAmmo + 10;
            Destroy(gameObject, 0.1f);
        }
    }
}