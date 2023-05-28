using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool colD = true;
    int vida = 100;
    public Animator animator;
    public Collider collider;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public ParticleSystem particleSystem;
    public HealthManager healthManager;
    public GameObject municion;
    public GameObject heal;
    GameObject player;
    bool isIn;
    bool done = false;

    void Start()
    {
        player = GameObject.Find("Player");
        healthManager = GameObject.Find("Player").GetComponent<HealthManager>();
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
            agent.destination = player.transform.position;
        }
        if (vida <= 0)
        {
            Destroy(gameObject);
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

    private void OnDestroy()
    {
        float randomFloat = Random.value;

        if (randomFloat >= 0.5f)
        {
            Instantiate(municion, transform.position, municion.transform.rotation);
            Instantiate(heal, transform.position, heal.transform.rotation);
        }
    }
}
