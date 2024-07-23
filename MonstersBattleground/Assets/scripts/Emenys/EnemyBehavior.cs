using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private ZombieStats _zombieStats;
    private Transform target;

    void Update()
    {
        FindClosestPlayer();
        if (target != null)
        {
            // Mover o inimigo em direção ao jogador mais próximo
            transform.position = Vector3.MoveTowards(transform.position, target.position, _zombieStats.ZombieSpeed * Time.deltaTime);

            // Fazer o inimigo olhar para o jogador
            Vector3 lookDirection = target.position - transform.position;
            lookDirection.y = 0; // Mantenha a rotação apenas no plano horizontal
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }

    void FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float shortestDistance = Mathf.Infinity;
        GameObject closestPlayer = null;

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                closestPlayer = player;
            }
        }

        if (closestPlayer != null)
        {
            target = closestPlayer.transform;
        }


    }

}
