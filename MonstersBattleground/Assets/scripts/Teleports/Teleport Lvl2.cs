using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportLvl2 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Nivel 2");
        }
    }
}
