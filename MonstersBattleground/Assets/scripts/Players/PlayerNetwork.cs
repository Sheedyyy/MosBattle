using UnityEngine;
using Unity.Netcode;
using UnityEngine.EventSystems;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private float _moveDirectionValue;
    [SerializeField] private float _rotationAngle;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

   
    private void Update()
    {
        if (!IsOwner) { return; } // Se não for o dono do objeto, não executa o código abaixo
        UpdateMovementServerAuth();
        //UpdateMovement(); 
    }

    private void UpdateMovement()
    {
        Vector3 moveDirection = Vector3.zero;
        Quaternion rotationMovement = Quaternion.identity;
        // UpdateMovement é uma função que controla o movimento do jogador
        if (Input.GetKey(KeyCode.W)) { moveDirection.z = _moveDirectionValue; }
        if (Input.GetKey(KeyCode.S)) { moveDirection.z = -_moveDirectionValue; }
        if (Input.GetKey(KeyCode.A)) { moveDirection.x = -_moveDirectionValue; }
        if (Input.GetKey(KeyCode.D)) { moveDirection.x = _moveDirectionValue; }

        if (Input.GetKey(KeyCode.Q)) { rotationMovement.y = -_rotationAngle; }
        if (Input.GetKey(KeyCode.E)) { rotationMovement.y = _rotationAngle; }


        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationMovement.y * _rotationSpeed * Time.deltaTime);
    }

    private void UpdateMovementServerAuth()
    {
        Vector3 moveDirection = Vector3.zero;
        Quaternion rotationMovement = Quaternion.identity;
        // UpdateMovement é uma função que controla o movimento do jogador
        if (Input.GetKey(KeyCode.W)) { moveDirection.z = _moveDirectionValue; }
        if (Input.GetKey(KeyCode.S)) { moveDirection.z = -_moveDirectionValue; }
        if (Input.GetKey(KeyCode.A)) { moveDirection.x = -_moveDirectionValue; }
        if (Input.GetKey(KeyCode.D)) { moveDirection.x = _moveDirectionValue; }

        if (Input.GetKey(KeyCode.Q)) { rotationMovement.y = -_rotationAngle; }
        if (Input.GetKey(KeyCode.E)) { rotationMovement.y = _rotationAngle; }

        // Chamada ao serverRpc com a passagem de parâmetros
        UpdateMovementServerRpc(moveDirection, rotationMovement);
    }

    [ClientRpc]
    public void TestClientRpc()
    {
        Debug.Log("Teste");
    }

    [ServerRpc(RequireOwnership = false)]
    private void UpdateMovementServerRpc(Vector3 moveDirection, Quaternion rotationMovement)
    {
        // Atualiza a posição e rotação do jogador
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationMovement.y * _rotationSpeed * Time.deltaTime);
        
    }


}
