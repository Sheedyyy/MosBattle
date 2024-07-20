using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{

    [SerializeField] private List<GameObject> _playerPrefab;

    private GameObject playerPrefabInstance;

    private void Awake()
    {
        playerPrefabInstance = new GameObject();
    }

    public void SetPlayerPrefab(int index)
    {
        playerPrefabInstance = _playerPrefab[index];

    }

}