using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotationSpeed = 5f;

    private void Update()
    {
        // Calcula a dire��o do jogador
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0f; // Ignora o eixo y

        // Rotaciona o inimigo para olhar na dire��o do jogador
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move o inimigo em dire��o ao jogador
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
