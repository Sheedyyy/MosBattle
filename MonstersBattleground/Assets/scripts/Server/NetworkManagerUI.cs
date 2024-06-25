using Unity.Netcode;
using UnityEngine;

public class NetworkManagerUI : MonoBehaviour
{
    #region Server

    public void StartServer()
    {
        NetworkManager.Singleton.StartServer();
    }

    #endregion

    #region Client

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    #endregion

    #region Host

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    #endregion
}
