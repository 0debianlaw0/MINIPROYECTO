using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] float fireRate;
    [SerializeField] bool semiAuto;
    float fireRateTimer;

    [Header("Bullet Properties")]
    [SerializeField] Rigidbody bullet;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletsPerShot;
    AimStateManager aim;

    [SerializeField] AudioClip gunShot;
    AudioSource audioSource;
    WeaponAmmo ammo;
    ActionStateManager actions;
    WeaponRecoil recoil;
    Vector3 targetPoint;
    Vector3 startingDirection;
    public float rotationSpeed;

    public Camera cam;
    Light muzzleFlashLight;
    ParticleSystem muzzleFlashParticles;
    float lightIntensity;
    [SerializeField] float lightReturnSpeed = 20;
    private MUNICIONHASTAAQUIHEMOSLLEGAO _municionhastaaquihemosllegao;
    

    // Start is called before the first frame update
    void Start()
    {
        
        recoil = GetComponent<WeaponRecoil>();
        ammo = GetComponent<WeaponAmmo>();
        audioSource = GetComponent<AudioSource>();
        aim = GetComponentInParent<AimStateManager>();
        actions = GetComponentInParent<ActionStateManager>();
        muzzleFlashLight = GetComponentInChildren<Light>();
        lightIntensity = muzzleFlashLight.intensity;
        muzzleFlashLight.intensity = 0;
        muzzleFlashParticles = GetComponentInChildren<ParticleSystem>();
        _municionhastaaquihemosllegao = GameObject.Find("MUNICION").GetComponent<MUNICIONHASTAAQUIHEMOSLLEGAO>();
        fireRateTimer = fireRate;
        startingDirection = barrelPos.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldFire()) Fire();
        muzzleFlashLight.intensity = Mathf.Lerp(muzzleFlashLight.intensity, 0, lightReturnSpeed * Time.deltaTime);
        Debug.DrawRay(barrelPos.position, (targetPoint - barrelPos.position) * bulletVelocity, Color.yellow);
    }

    bool ShouldFire()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer < fireRate) return false;
        if (_municionhastaaquihemosllegao.currentAmmo == 0) return false;
        if (actions.currentState == actions.Reload) return false;
        if (semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if (!semiAuto && Input.GetKey(KeyCode.Mouse0)) return true;
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        barrelPos.LookAt(aim.aimPos);
        audioSource.PlayOneShot(gunShot);
        recoil.TriggerRecoil();
        TriggerMuzzleFlash();
        _municionhastaaquihemosllegao.currentAmmo--;
        for (int i = 0; i < bulletsPerShot; i++)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                targetPoint = hit.transform.position - barrelPos.position;

            }
            else
            {
                targetPoint = startingDirection;
            }
            Vector3 newDirection = Vector3.RotateTowards(barrelPos.transform.forward, targetPoint, rotationSpeed * Time.deltaTime, 0.0f);
            barrelPos.transform.forward = newDirection;
            Rigidbody clone;
            clone = Instantiate(bullet, barrelPos.position, barrelPos.rotation) as Rigidbody;
            clone.velocity = targetPoint * bulletVelocity;


        }
    }

    void TriggerMuzzleFlash()
    {
        muzzleFlashParticles.Play();
        muzzleFlashLight.intensity = lightIntensity;
    }
}
