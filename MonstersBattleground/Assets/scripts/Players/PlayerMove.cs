using Unity.Netcode;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : NetworkBehaviour
{
    #region variaveis

    [Header("ScriptableObjects")]
    [SerializeField]private PlayerStatus _playerStatus;

    private NetworkVariable<int> randomNumber = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    #endregion

    #region Spawn do player

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Debug.Log($"Player spawned: {OwnerClientId}");
        randomNumber.OnValueChanged += OnValueChanged;
    }

    private void OnValueChanged(int previousValue, int newValue)
    {
        Debug.Log($"{OwnerClientId}; randomNumber: {randomNumber.Value}");
    }
    private void Update()
    {

        UpdateMovement();
    }

    #endregion

    #region Movimentação do player

    

    private void UpdateMovement()
    {
        Vector3 moveDirection = Vector3.zero;
        Quaternion rotationMovement = Quaternion.identity;

        if (Input.GetKey(KeyCode.W)) { moveDirection.z = _playerStatus.MoveDirectionValue; }
        if (Input.GetKey(KeyCode.S)) { moveDirection.z = -_playerStatus.MoveDirectionValue; }
        if (Input.GetKey(KeyCode.A)) { moveDirection.z = -_playerStatus.MoveDirectionValue; }
        if (Input.GetKey(KeyCode.D)) { moveDirection.z = _playerStatus.MoveDirectionValue; }

        transform.position += moveDirection * _playerStatus.MoveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationMovement.y * _playerStatus.RotationSpeed * Time.deltaTime);
    }

    private void UpdateMovementServerAuth()
    {
        Vector3 moveDirection = Vector3.zero;
        Quaternion rotationMovement = Quaternion.identity;

        if (Input.GetKey(KeyCode.W)) { moveDirection.z = _playerStatus.MoveDirectionValue; }
        if (Input.GetKey(KeyCode.S)) { moveDirection.z = -_playerStatus.MoveDirectionValue; }
        if (Input.GetKey(KeyCode.A)) { moveDirection.z = -_playerStatus.MoveDirectionValue; }
        if (Input.GetKey(KeyCode.D)) { moveDirection.z = _playerStatus.MoveDirectionValue; }

        UpdateMovementServerRpc(moveDirection, rotationMovement);
    }

    #endregion

    #region RPCs

    [ServerRpc]

    public void TesteServerRpc(string message)
    {
        Debug.Log($"TesteServerRpc: {OwnerClientId}; Message: {message}");
    }
    [ClientRpc]

    public void TesteClientRpc()
    {
        Debug.Log($"TesteClientRpc");
    }

    [ServerRpc(RequireOwnership = false)]

    public void UpdateMovementServerRpc(Vector3 moveDirection, Quaternion rotationMovement)
    {
        transform.position += moveDirection * _playerStatus.MoveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationMovement.y * _playerStatus.RotationSpeed * Time.deltaTime);
    }

    #endregion

}
