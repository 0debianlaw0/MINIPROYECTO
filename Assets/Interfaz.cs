using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class Interfaz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoVida;
    [SerializeField] TMP_Text textoAmmo;
    [SerializeField] TMP_Text textoClip;
    [SerializeField] TMP_Text textoClip2;
    [SerializeField] HealthManager healthManager;
    [SerializeField] WeaponAmmo weaponAmmo;
    [SerializeField] WeaponAmmo weaponAmmo2;
    private MUNICIONHASTAAQUIHEMOSLLEGAO _municionhastaaquihemosllegao;
    // Update is called once per frame

    private void Start()
    {
        _municionhastaaquihemosllegao = GameObject.Find("MUNICION").GetComponent<MUNICIONHASTAAQUIHEMOSLLEGAO>();
    }

    public void Update()
    {
        textoVida.SetText(healthManager.currentHealth.ToString());
        textoAmmo.SetText(_municionhastaaquihemosllegao.currentAmmo.ToString());
        textoClip.SetText(weaponAmmo.extraAmmo.ToString());
        textoClip2.SetText(weaponAmmo2.extraAmmo.ToString());
    }
}
