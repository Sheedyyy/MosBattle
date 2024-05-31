using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private WebRequest webRequest;

    private PlayerInfo _playerInfo;

    public PlayerInfo PlayerInfo
    {
        get => _playerInfo; //retorna o objeto PlayerInfo
        set => _playerInfo = value; //define o objeto PlayerInfo
    }

    void Start()
    {
        PlayerInfo = new PlayerInfo();//cria um objeto PlayerInf

        webRequest.OnGetRequest("/getPlayerStatus"); //inicia a requisição
    }
}
