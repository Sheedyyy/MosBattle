using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Player/PlayerStatus", order = 1)]

public class PlayerStatus : ScriptableObject
{
    [Header("Velocidade do player")]
    [SerializeField] private float _speed;
    [SerializeField] private float _verticalVelocity;
    [SerializeField] private float _sprint;

    [Header("Salto do player")]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravity;

    [Header("Ataque do player")]
    [SerializeField] private int _attack;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public float VerticalVelocity
    {
        get => _verticalVelocity;
        set => _verticalVelocity = value;
    }

    public float Sprint
    {
        get => _sprint;
        set => _sprint = value;
    }


    public float JumpHeight
    {
        get => _jumpHeight;
        set => _jumpHeight = value;
    }

    public float Gravity
    {
        get => _gravity;
        set => _gravity = value;
    }

    public int Attack
    {
        get => _attack;
        set => _attack = value;
    }
}
