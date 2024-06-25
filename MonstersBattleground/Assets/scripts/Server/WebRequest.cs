using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerActions playerActions;

    [Header("Server Data")]
    [SerializeField] private string host;
    [SerializeField] private string port;

    [Header("Server Properties")]
    [SerializeField] private int timeOutSeconds;

    private string _urlGetPath;

    void Awake()
    {
        _urlGetPath = "http://" + host + ":" + port; //define a url base
    }

    public void OnGetRequest(string urlGetPath)
    {
        StartCoroutine(GetRequest(_urlGetPath + urlGetPath)); //faz a requisição get
    }

    IEnumerator GetRequest(string urlGetRequest)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(urlGetRequest); //cria a requisição

        webRequest.timeout = timeOutSeconds; //  define o tempo limite da requisição

        yield return webRequest.SendWebRequest(); //envia a requisição

        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError) //verifica se houve erro
        {
            Debug.Log($"Error: {webRequest.error} "); //mostra o erro
        }
        else
        {
            string responseRecived = webRequest.downloadHandler.text; //pega a resposta

            playerActions.PlayerInfo.playerData = playerActions.PlayerInfo.CreateFromJson(responseRecived); //converte a resposta para o objeto PlayerData

            //Debug.Log($"Response: {responseRecived} "); //mostra a resposta
            Debug.Log($"ID: {playerActions.PlayerInfo.playerData.playerDataValues[0].pla_id} ");
            Debug.Log($"Name: {playerActions.PlayerInfo.playerData.playerDataValues[0].pla_nome} ");
            Debug.Log($"HP: {playerActions.PlayerInfo.playerData.playerDataValues[0].pla_hp} ");
        }

    }
}
