using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private WebRequest webRequest;//referencia para o script WebRequest

    private PlayerInfo _playerInfo;

    public PlayerInfo PlayerInfo
    {
        get => _playerInfo; //retorna o objeto PlayerInfo
        set => _playerInfo = value; //define o objeto PlayerInfo
    }

    void Start()
    {
        PlayerInfo = new PlayerInfo();//cria um objeto PlayerInfo

        webRequest.OnGetRequest("/get-Player-Status");//faz a requisição para o servidor
    }
}
