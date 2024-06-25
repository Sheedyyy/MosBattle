using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    #region variaveis

    [Header("ScriptableObjects")]
    [SerializeField]private PlayerStatus _playerStatus;

    [SerializeField] private Transform spawnedObjectPrefab;
    private Transform spawnedObjectTransform;

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
        if (!IsOwner) { return; }

        if (Input.GetKeyDown(KeyCode.T))
        {
            spawnedObjectTransform = Instantiate(spawnedObjectPrefab);
            spawnedObjectTransform.GetComponent<NetworkObject>().Spawn(true);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            spawnedObjectTransform.GetComponent<NetworkObject>().Despawn(true);
        }

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
