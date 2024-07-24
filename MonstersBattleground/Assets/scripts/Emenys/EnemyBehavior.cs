using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    public Transform Player;
    public Transform Player2;
    [SerializeField] private ZombieStats _zombieStats;
    private Transform target;

    private void Start()
    {
        Player = Player2;
    }
    void Update()
    {
        FindClosestPlayer();
        if (target != null)
        {
            // Mover o inimigo em dire��o ao jogador mais pr�ximo
            transform.position = Vector3.MoveTowards(transform.position, target.position, _zombieStats.ZombieSpeed * Time.deltaTime);

            // Fazer o inimigo olhar para o jogador
            Vector3 lookDirection = target.position - transform.position;
            lookDirection.y = 0; // Mantenha a rota��o apenas no plano horizontal
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

    public void TakeDamage(float damage)
    {
        _zombieStats.ZombieLife -= damage;

        if (_zombieStats.ZombieLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerLife  = collision.gameObject.GetComponent<Player>();
            if (playerLife != null)
            {
                SceneManager.LoadScene("MenuGameOver");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gun"))
        {
            // Destruir o zumbi quando colidir com a arma
            Destroy(gameObject);
        }
    }
}
