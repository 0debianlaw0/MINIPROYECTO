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
    public ParticleSystem particleSystem;
    public HealthManager healthManager;
    bool isIn;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        collider = GetComponent<Collider>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (colD == true)
        {
            agent.destination = goal.position;
            TenSeconds();
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
            animator.SetBool("RUN", true);
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
        if (isIn == true)
        {
            healthManager.currentHealth -= 10;
        }
    }

    IEnumerator TenSeconds()
    {
        yield return new WaitForSeconds(10f);
        particleSystem.Play();
        Destroy(gameObject, 0.5f);
    }
}
