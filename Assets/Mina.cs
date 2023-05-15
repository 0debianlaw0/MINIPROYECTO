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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity, layerMask) && used == false)
        {
            used = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            particleSystem.Play();
            healthManager.DamagePlayer(30);
            Destroy(gameObject, 0.5f);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
    }
}