using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{
    public int clipSize;
    public int extraAmmo;
    [HideInInspector] public int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = clipSize;
    }

    
}
