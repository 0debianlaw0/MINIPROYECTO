using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{
    public int clipSize;
    public int extraAmmo;
    //public int currentAmmo;
    public int ammoToReload;

    public AudioClip magInSound;
    public AudioClip magOutSound;
    public AudioClip releaseSlideSound;
    private MUNICIONHASTAAQUIHEMOSLLEGAO _municionhastaaquihemosllegao;
    // Start is called before the first frame update
    void Start()
    {
        _municionhastaaquihemosllegao = GameObject.Find("MUNICION").GetComponent<MUNICIONHASTAAQUIHEMOSLLEGAO>();
        _municionhastaaquihemosllegao.currentAmmo = clipSize;
    }

    

    public void Reload()
    {
        if (extraAmmo >= clipSize)
        {
            ammoToReload = clipSize - _municionhastaaquihemosllegao.currentAmmo;
            extraAmmo -= ammoToReload;
            _municionhastaaquihemosllegao.currentAmmo += ammoToReload;
        }
        else if (extraAmmo > 0)
        {
            if (extraAmmo + _municionhastaaquihemosllegao.currentAmmo > clipSize)
            {
                int leftOverAmmo = extraAmmo + _municionhastaaquihemosllegao.currentAmmo - clipSize;
                extraAmmo = leftOverAmmo;
                _municionhastaaquihemosllegao.currentAmmo = clipSize;
            }
            else
            {
                _municionhastaaquihemosllegao.currentAmmo += extraAmmo;
                extraAmmo = 0;
            }
        }
    }
}
