using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    float horizontalInput, verticalInput;
    public float transformYSave;
    [HideInInspector] public Vector3 direction;

    [Header ("Inputs")]
    [SerializeField] string hInputName;
    [SerializeField] string vInputName;

    [Header ("Speed")]
    [SerializeField] public float moveSpeed = 3;

    [Header ("CharacterController")]
    [SerializeField] CharacterController characterController;

    [Header ("Ground")]
    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePosition;

    [Header ("Gravity")]
    [SerializeField] float gravity = Physics.gravity.y;
    Vector3 velocity;

    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Move();
        Gravity();
    }

    void Move()
    {
        horizontalInput = Input.GetAxis(hInputName);
        verticalInput = Input.GetAxis(vInputName);
        
        direction = transform.forward * verticalInput + transform.right * horizontalInput;
        characterController.Move(direction.normalized * moveSpeed * Time.deltaTime);        
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
