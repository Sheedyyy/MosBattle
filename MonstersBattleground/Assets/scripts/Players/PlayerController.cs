using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;


public class PlayerController : NetworkBehaviour
{

    #region Variables

    [Header("Chamada dos scriptableObejects")]
    [SerializeField] private PlayerStatus _playerStatus;
    [SerializeField] private InputPlayer inputPlayer;

    [Header("Movimenta��o do player")]
    private Vector2 moveVector;
    private CharacterController characterController;
    private bool isSprinting = false;


    [Header("Movimenta��o da camera do player")]
    [SerializeField] private float _lookSenesitivity;
    [SerializeField] private Slider _lookSensitivitySlider;

    [Header("morrer")]
    [SerializeField] private Playerlife maxLife;

    private Vector2 lookVector;
    private Vector3 rotation;

    // [Header("Anima��es do player")]
    // private Animator animator;
    #endregion

    #region Movimenta��o do player

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();

        inputPlayer.FindAction("SprintStart").started += ctx => StartSprinting();
        inputPlayer.FindAction("SprintFinish").canceled += ctx => StopSprinting();
    }

    void Update()
    {
        Move();
        Rotate();
    }



    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();

        /* if (moveVector.magnitude > 0)
         {
             animator.SetBool("isWalking", true);
         }
         else
         {
             animator.SetBool("isWalking", false);
         }*/

    }

    private void Move()
    {
        _playerStatus.MoveSpeed += -_playerStatus.Gravity * Time.deltaTime;

        if (characterController.isGrounded && _playerStatus.MoveSpeed < 0)
        {
            _playerStatus.MoveSpeed = -0.1f * _playerStatus.Gravity * Time.deltaTime;
        }

        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.y + transform.up * _playerStatus.MoveSpeed;
        characterController.Move(move * _playerStatus.MoveSpeed * Time.deltaTime);
    }

    private void StartSprinting()
    {
        isSprinting = true;

    }

    private void StopSprinting()
    {
        isSprinting = false;
    }

    #endregion

    #region Movimenta��o da camera do player
    public void OnLook(InputAction.CallbackContext context)
    {
        lookVector = context.ReadValue<Vector2>();
    }

    private void Rotate()
    {

        rotation.y += lookVector.x * _lookSenesitivity * Time.deltaTime;
        transform.localEulerAngles = rotation;
        _lookSenesitivity = _lookSensitivitySlider.value;
    }
    #endregion

    #region Salto do player
    public void OnJump(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded && context.performed)
        {
            //animator.Play("Jump");
            Jump();
        }
    }

    private void Jump()
    {
        _playerStatus.MoveSpeed = Mathf.Sqrt(_playerStatus.JumpHeight * _playerStatus.Gravity);
    }
    #endregion

    #region Morrer

   /* public void TakeDamage(int damageAmount)
    {
        maxLife.value -= damageAmount;
        if (maxLife.value <= 0)
        {

        }


    }*/
    #endregion
}

