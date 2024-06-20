using Unity.Netcode;
using UnityEngine;

public class NetworkManagerUI : MonoBehaviour
{
    public void StartServer()
    {
<<<<<<< Updated upstream
        NetworkManager.Singleton.StartServer();//inicia o servidor
=======
        NetworkManager.Singleton.StartServer();
>>>>>>> Stashed changes
    }

    public void StartHost()
    {
<<<<<<< Updated upstream
        NetworkManager.Singleton.StartHost(); //inicia o host
=======
        NetworkManager.Singleton.StartHost();
>>>>>>> Stashed changes
    }

    public void StartClient()
    {
<<<<<<< Updated upstream
        NetworkManager.Singleton.StartClient(); //inicia o cliente
=======
        NetworkManager.Singleton.StartClient();
>>>>>>> Stashed changes
    }
}
