using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CharacterMovement : NetworkBehaviour
{
    #region Variables

    [Header("Chamada do playerSatus")]
    [SerializeField] private PlayerStatus _playerStatus;

    [Header("Colisoes")]
    [SerializeField] private LayerMask collisionsLayerMask;

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

        HandleMovementServerAuth();
        
    }

    /* public bool IsWalking()
     {
         return isWalking;
     }*/

    private void HandleMovementServerAuth()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();

        HandleMovementServerRPC(inputVector);
    }

    [ServerRpc(RequireOwnership = false)]
    private void HandleMovementServerRPC(Vector2 inputVector) 
    {

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = _playerStatus.MoveSpeed * Time.deltaTime;
        float playerRadius = .6f;
        bool canMove = !Physics.BoxCast(transform.position, Vector3.one * playerRadius, moveDir, Quaternion.identity, moveDistance, collisionsLayerMask);

        if (!canMove)
        {
            // Cannot move towards moveDir

            // Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = (moveDir.x < -.5f || moveDir.x > +.5f) && !Physics.BoxCast(transform.position, Vector3.one * playerRadius, moveDirX, Quaternion.identity, moveDistance, collisionsLayerMask);

            if (canMove)
            {
                // Can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move only on the X

                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = (moveDir.z < -.5f || moveDir.z > +.5f) && !Physics.BoxCast(transform.position, Vector3.one * playerRadius, moveDirZ, Quaternion.identity, moveDistance, collisionsLayerMask);

                if (canMove)
                {
                    // Can move only on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move in any direction
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }
    #endregion


}
