using UnityEngine;

[CreateAssetMenu(fileName = "PlayerLife", menuName = "PlayerLife")]

public class Playerlife : ScriptableObject
{
    [Header("Vida do player")]
    [SerializeField] private int _life;
    [SerializeField] private int _maxLife;

    [Header("Barra de vida")]
    [SerializeField] private int _lifeBar;

    public int Life
    {
        get => _life;
        set => _life = value;
    }

    public int MaxLife
    {
        get => _maxLife;
        set => _maxLife = value;
    }

    public int LifeBar
    {
        get => _lifeBar;
        set => _lifeBar = value;
    }

    
}
