using Unity.Netcode;
using UnityEngine;

public class NetworkManagerUI : MonoBehaviour
{
    public void StartServer()
    {
        NetworkManager.Singleton.StartServer();//inicia o servidor
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost(); //inicia o host
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient(); //inicia o cliente
    }
}
