using UnityEngine;

public class Mina : MonoBehaviour
{
    public LayerMask layerMask;
    [SerializeField] HealthManager healthManager;
    [SerializeField] new ParticleSystem particleSystem;
    bool used = false;

    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    void FixedUpdate()
    {

        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask) && used == false)
        {
            used = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            particleSystem.Play();
            healthManager.DamagePlayer(30);
            GameObject.Destroy(gameObject, 0.5f);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
    }
}