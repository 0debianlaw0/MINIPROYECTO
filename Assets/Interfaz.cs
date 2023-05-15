using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interfaz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoVida;
    [SerializeField] TMP_Text textoAmmo;
    [SerializeField] TMP_Text textoAmmo2;
    [SerializeField] TMP_Text textoClip;
    [SerializeField] TMP_Text textoClip2;
    [SerializeField] HealthManager healthManager;
    [SerializeField] WeaponAmmo weaponAmmo;
    [SerializeField] WeaponAmmo weaponAmmo2;
    // Update is called once per frame

    public void Update()
    {
        textoVida.SetText(healthManager.currentHealth.ToString());
        textoAmmo.SetText(weaponAmmo.currentAmmo.ToString());
        textoAmmo2.SetText(weaponAmmo2.currentAmmo.ToString());
        textoClip.SetText(weaponAmmo.extraAmmo.ToString());
        textoClip2.SetText(weaponAmmo2.extraAmmo.ToString());
    }
}
