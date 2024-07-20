using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LobbyListSingleUI : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _lobbyNameText;


    private Lobby lobby;


    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            GameLobby.Instance.JoinWithId(lobby.Id);
        });
    }

    public void SetLobby(Lobby lobby)
    {
        this.lobby = lobby;
        _lobbyNameText.text = lobby.Name;
    }

}