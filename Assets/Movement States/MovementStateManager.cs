using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    [HideInInspector] public float horizontalInput, verticalInput;
    public float transformYSave;
    [HideInInspector] public Vector3 direction;

    [Header ("Inputs")]
    [SerializeField] string hInputName;
    [SerializeField] string vInputName;

    [Header ("Speed")]
    [SerializeField] public float currentMoveSpeed;
    public float walkSpeed = 3, walkBackSpeed = 2;
    public float runSpeed = 7, runBackSpeed = 5;
    public float crouchSpeed = 2, crouchBackSpeed = 1;

    [Header ("CharacterController")]
    [SerializeField] CharacterController characterController;

    [Header ("Ground")]
    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePosition;

    [Header ("Gravity")]
    [SerializeField] float gravity = Physics.gravity.y;
    Vector3 velocity;

    MovementBaseStates currentState;

    public idleState Idle = new idleState();
    public walkState Walk = new walkState();
    public runningState Run = new runningState();
    public crouchState Crouch = new crouchState();

    [HideInInspector] public Animator animator;
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        SwitchState(Idle);
    }

    void Update()
    {
        animator.SetFloat("hzInput", horizontalInput);
        animator.SetFloat("vInput", verticalInput);

        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        Move();
        Gravity();
    }
    public void SwitchState(MovementBaseStates state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    void Move()
    {
        horizontalInput = Input.GetAxis(hInputName);
        verticalInput = Input.GetAxis(vInputName);
        
        direction = transform.forward * verticalInput + transform.right * horizontalInput;
        characterController.Move(direction.normalized * currentMoveSpeed * Time.deltaTime);        
    }

    bool IsGrounded()
    {
        spherePosition = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePosition, characterController.radius - 0.05f, groundMask))
            return true;
        else
            return false;
    }

    void Gravity()
    {
        if (!IsGrounded())
            velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0)
            velocity.y = -1;

        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(spherePosition, characterController.radius - 0.05f);
    }
}
