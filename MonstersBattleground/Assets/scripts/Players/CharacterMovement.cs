using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CharacterMovement : NetworkBehaviour
{
    #region Variables

    [Header("Chamada do playerSatus")]
    [SerializeField] private PlayerStatus _playerStatus;

    [Header("Animacoes")]
    private bool isWalking;

    #endregion

    #region Movimento

    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }

        HandleMovement();
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    private void HandleMovement()
    {
        
    }

    #endregion
}
