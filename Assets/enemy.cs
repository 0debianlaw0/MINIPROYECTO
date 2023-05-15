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

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (colD == true)
        {
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
            animator.SetBool("RUN", true);
            colD = true;

        }
    }

    public void Damage()
    {
        vida = vida - 100;
    }

    IEnumerator TenSeconds()
    {
        yield return new WaitForSeconds(10f);
    }
}
