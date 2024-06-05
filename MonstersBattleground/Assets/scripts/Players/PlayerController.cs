using System;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    [Header("Chamada dos scriptableObejects")]
    [SerializeField] private PlayerStatus _playerStatus;

    [Header("Movimentação do player")]
    private Vector2 moveVector;
    private CharacterController characterController;
    

    [Header("Movimentação da camera do player")]
    [SerializeField] private float _lookSenesitivity;

    private Vector2 lookVector;
    private Vector3 rotation;

    [Header("Animações do player")]
    private Animator animator;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Rotate();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();

        if (moveVector.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

    }

    private void Move()
    {
        _playerStatus.VerticalVelocity += -_playerStatus.Gravity * Time.deltaTime;

        if (characterController.isGrounded && _playerStatus.VerticalVelocity < 0)
        {
            _playerStatus.VerticalVelocity = -0.1f * _playerStatus.Gravity * Time.deltaTime;
        }

        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.y + transform.up * _playerStatus.VerticalVelocity;
        characterController.Move(move * _playerStatus.Speed * Time.deltaTime);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookVector = context.ReadValue<Vector2>();
    }

    private void Rotate()
    {

        rotation.y += lookVector.x * _lookSenesitivity * Time.deltaTime;
        transform.localEulerAngles = rotation;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded && context.performed)
        {
            animator.Play("Jump");
            //Jump();
        }
    }

    private void Jump()
    {
        _playerStatus.VerticalVelocity = Mathf.Sqrt(_playerStatus.JumpHeight * _playerStatus.Gravity);
    }
}
