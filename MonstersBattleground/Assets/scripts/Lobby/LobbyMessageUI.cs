using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMessageUI : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private Button _closeButton;


    private void Awake()
    {
        _closeButton.onClick.AddListener(Hide);
    }

    private void Start()
    {
        GameMultiplayer.Instance.OnFailedToJoinGame += GameMultiplayerOnFailedToJoinGame;
        GameLobby.Instance.OnCreateLobbyStarted += GameLobbyOnCreateLobbyStarted;
        GameLobby.Instance.OnCreateLobbyFailed += GameLobbyOnCreateLobbyFailed;
        GameLobby.Instance.OnJoinStarted += GameLobbyOnJoinStarted;
        GameLobby.Instance.OnJoinFailed += GameLobbyOnJoinFailed;
        GameLobby.Instance.OnQuickJoinFailed += GameLobbyOnQuickJoinFailed;

        Hide();
    }

    private void GameLobbyOnQuickJoinFailed(object sender, System.EventArgs e)
    {
        ShowMessage("Could not find a Lobby to Quick Join!");
    }

    private void GameLobbyOnJoinFailed(object sender, System.EventArgs e)
    {
        ShowMessage("Failed to join Lobby!");
    }

    private void GameLobbyOnJoinStarted(object sender, System.EventArgs e)
    {
        ShowMessage("Joining Lobby...");
    }

    private void GameLobbyOnCreateLobbyFailed(object sender, System.EventArgs e)
    {
        ShowMessage("Failed to create Lobby!");
    }

    private void GameLobbyOnCreateLobbyStarted(object sender, System.EventArgs e)
    {
        ShowMessage("Creating Lobby...");
    }

    private void GameMultiplayerOnFailedToJoinGame(object sender, System.EventArgs e)
    {
        if (NetworkManager.Singleton.DisconnectReason == "")
        {
            ShowMessage("Failed to connect");
        }
        else
        {
            ShowMessage(NetworkManager.Singleton.DisconnectReason);
        }
    }

    private void ShowMessage(string message)
    {
        Show();
        _messageText.text = message;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameMultiplayer.Instance.OnFailedToJoinGame -= GameMultiplayerOnFailedToJoinGame;
        GameLobby.Instance.OnCreateLobbyStarted -= GameLobbyOnCreateLobbyStarted;
        GameLobby.Instance.OnCreateLobbyFailed -=GameLobbyOnCreateLobbyFailed;
        GameLobby.Instance.OnJoinStarted -= GameLobbyOnJoinStarted;
        GameLobby.Instance.OnJoinFailed -= GameLobbyOnJoinFailed;
        GameLobby.Instance.OnQuickJoinFailed -= GameLobbyOnQuickJoinFailed;
    }

}