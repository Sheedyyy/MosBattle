using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Player/PlayerStatus", order = 1)]

public class PlayerStatus : ScriptableObject
{
    #region Variaveis

    [Header("Velocidade do player")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveDirectionValue;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotationAngle;


    /*[Header("Salto do player")]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravity;

    [Header("Ataque do player")]
    [SerializeField] private int _attack;*/

    #endregion

    #region Getters and Setters

    public float MoveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }

    public float MoveDirectionValue
    {
        get => _moveDirectionValue;
        set => _moveDirectionValue = value;
    }

    public float RotationSpeed
    {
        get => _rotationSpeed;
        set => _rotationSpeed = value;
    }

    public float RotationAngle
    {
        get => _rotationAngle;
        set => _rotationAngle = value;
    }
    

    #endregion
}
