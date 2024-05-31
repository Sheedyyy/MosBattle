using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerActions playerActions;

    [Header("ServerData")]
    [SerializeField] private string host;
    [SerializeField] private string port;

    [Header("Server properties")]
    [SerializeField] private int timeoutSeconds;

    private string _urlGetPath;

    void Awake()
    {
        _urlGetPath = "http://" + host + ":" + port; //define a url de requisição
    }

    public void OnGetRequest(string urlGetPath)
    {
        StartCoroutine(GetRequest(_urlGetPath + urlGetPath)); //inicia a coroutine de requisição
    }

    IEnumerator GetRequest(string urlGetRequest)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(urlGetRequest); //cria a requisição

        webRequest.timeout = timeoutSeconds; //define o tempo limite da requisição
        yield return webRequest.SendWebRequest(); //envia a requisição

        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError) //verifica se houve erro na requisição
        {
            Debug.Log($"Error: {webRequest.error}"); //exibe o erro
        }
        else
        {
            string responseReceived = webRequest.downloadHandler.text; //pega a resposta da requisição
            Debug.Log($"Response: {responseReceived}"); //exibe a resposta

            playerActions.PlayerInfo.playerData = playerActions.PlayerInfo.CreateFromJson(responseReceived); //converte a resposta para um objeto PlayerData

            Debug.Log($"ID: {playerActions.PlayerInfo.playerData.playerDataValues[0].pla_id}"); //exibe o id do player
            Debug.Log($"Nome: {playerActions.PlayerInfo.playerData.playerDataValues[0].pla_nome}"); //exibe o nome do player
            Debug.Log($"HP: {playerActions.PlayerInfo.playerData.playerDataValues[0].pla_hp}"); //exibe o hp do player
            Debug.Log($"Score: {playerActions.PlayerInfo.playerData.playerDataValues[0].pla_score}"); //exibe o score do player
        }
    }
}
