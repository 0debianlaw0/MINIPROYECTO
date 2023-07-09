using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickAmmo : MonoBehaviour
{
    
    private MUNICIONHASTAAQUIHEMOSLLEGAO _municionhastaaquihemosllegao;
    private void Start()
    {
        _municionhastaaquihemosllegao = GameObject.Find("MUNICION").GetComponent<MUNICIONHASTAAQUIHEMOSLLEGAO>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _municionhastaaquihemosllegao.currentAmmo = _municionhastaaquihemosllegao.currentAmmo + 10;
            Destroy(gameObject, 0.1f);
        }
    }
    
}
