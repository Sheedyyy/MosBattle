using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovent : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 _input;
    private Vector3 _direction;
    private CharacterController _characterController;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();//busca o componente CharacterController
    }
    void Update()
    {
        _characterController.Move(_direction * speed * Time.deltaTime); //move o player
    }


    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>(); //pega o valor do input
        _direction = new Vector3(_input.x, 0, _input.y); //define a direção do player
    }
}
