using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActionStateManager : MonoBehaviour
{
    [HideInInspector] public ActionBaseState currentState;

    public ReloadState Reload = new ReloadState();
    public DefaultState Default = new DefaultState();

    public GameObject currentWeapon;
    public GameObject currentWeapon2;
    [HideInInspector] public WeaponAmmo ammo;
    [HideInInspector] public WeaponAmmo ammo2;
    AudioSource audioSource;
    AudioSource audioSource2;

    [HideInInspector] public Animator animator;

    public MultiAimConstraint rHandAim;
    public TwoBoneIKConstraint lHandIK;


    // Start is called before the first frame update
    void Start()
    {
        SwitchState(Default);
        ammo = currentWeapon.GetComponent<WeaponAmmo>();
        ammo2 = currentWeapon2.GetComponent<WeaponAmmo>();
        audioSource = currentWeapon.GetComponent<AudioSource>();
        audioSource2 = currentWeapon2.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(ActionBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void WeaponReloaded()
    {
        if (currentWeapon.activeSelf == true)
        {
            ammo.Reload();
            SwitchState(Default);
        }
        
        if (currentWeapon2.activeSelf == false)
        {
            ammo2.Reload();
            SwitchState(Default);
        }
    }

    public void MagOut()
    {
        if (currentWeapon.activeSelf == true)
        {
            audioSource.PlayOneShot(ammo.magOutSound);
        }
        if (currentWeapon2.activeSelf == true)
        {
            audioSource2.PlayOneShot(ammo2.magOutSound);
        }
        
    }

    public void MagIn()
    {
        if (currentWeapon.activeSelf == true)
        {
            audioSource.PlayOneShot(ammo.magInSound);
        }
        if (currentWeapon2.activeSelf == true)
        {
            audioSource2.PlayOneShot(ammo2.magInSound);
        }


    }

    public void ReleaseSlide()
    {
        if (currentWeapon.activeSelf == true)
        {
            audioSource.PlayOneShot(ammo.releaseSlideSound);
        }
        if (currentWeapon2.activeSelf == true)
        {
            audioSource2.PlayOneShot(ammo2.releaseSlideSound);
        }


    }
}
