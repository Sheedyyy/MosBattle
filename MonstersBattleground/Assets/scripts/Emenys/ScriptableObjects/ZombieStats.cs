using UnityEngine;

[CreateAssetMenu(fileName = "ZombieStats", menuName = "ZombieStats")]
public class ZombieStats : ScriptableObject
{
    [SerializeField] private float _ZombieSpeed;
    [SerializeField] private float _ZombieDamage;
    [SerializeField] private float _ZombieLife;

    public float ZombieSpeed
    {
        get => _ZombieSpeed;
        set => _ZombieSpeed = value;
    }

    public float ZombieDamage
    {
        get => _ZombieDamage;
        set => _ZombieDamage = value;
    }

    public float ZombieLife
    {
        get => _ZombieLife;
        set => _ZombieLife = value;
    }
}
