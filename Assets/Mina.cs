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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            particleSystem.Play();
            healthManager.DamagePlayer(30);
            Destroy(gameObject, 0.5f);
        }
    }
}