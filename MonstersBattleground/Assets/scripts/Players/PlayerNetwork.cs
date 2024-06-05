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
        if (!IsOwner) { return; } // Se n�o for o dono do objeto, n�o executa o c�digo abaixo
        UpdateMovementServerAuth();
        //UpdateMovement(); 
    }

    private void UpdateMovement()
    {
        Vector3 moveDirection = Vector3.zero;
        Quaternion rotationMovement = Quaternion.identity;
        // UpdateMovement � uma fun��o que controla o movimento do jogador
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
        // UpdateMovement � uma fun��o que controla o movimento do jogador
        if (Input.GetKey(KeyCode.W)) { moveDirection.z = _moveDirectionValue; }
        if (Input.GetKey(KeyCode.S)) { moveDirection.z = -_moveDirectionValue; }
        if (Input.GetKey(KeyCode.A)) { moveDirection.x = -_moveDirectionValue; }
        if (Input.GetKey(KeyCode.D)) { moveDirection.x = _moveDirectionValue; }

        if (Input.GetKey(KeyCode.Q)) { rotationMovement.y = -_rotationAngle; }
        if (Input.GetKey(KeyCode.E)) { rotationMovement.y = _rotationAngle; }

        // Chamada ao serverRpc com a passagem de par�metros
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
        // Atualiza a posi��o e rota��o do jogador
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationMovement.y * _rotationSpeed * Time.deltaTime);
        
    }


}
