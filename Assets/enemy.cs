using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField]public Transform goal;
    public bool colD = false;
    int vida = 100;
    public Animator animator;
    public Collider collider;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public ParticleSystem particleSystem;
    public HealthManager healthManager;
    bool isIn;
    bool done = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        collider = GetComponent<Collider>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (colD == true)
        {
            StartCoroutine(TenSeconds());
            animator.SetBool("run", true);
            agent.destination = goal.position;
        }
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            colD = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isIn = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isIn = false;

        }
    }

    public void Damage()
    {
        vida = vida - 100;
    }

    public void DamagePlayer()
    {
        if (isIn == true && done == false)
        {
            done = true;
            healthManager.currentHealth = healthManager.currentHealth - 10;
        }
    }

    public IEnumerator TenSeconds()
    {
        yield return new WaitForSeconds(3f);
        DamagePlayer();
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        particleSystem.Play();
        Destroy(gameObject, 0.2f);
    }
}
