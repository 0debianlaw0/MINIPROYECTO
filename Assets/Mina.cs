using UnityEngine;

public class Mina : MonoBehaviour
{
    public LayerMask layerMask;
    [SerializeField] HealthManager healthManager;
    [SerializeField] new ParticleSystem particleSystem;
    public AudioClip audioClip;
    bool used = false;

    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            particleSystem.Play();
            healthManager.DamagePlayer(20);
            Destroy(gameObject, 0.5f);
        }
    }
}