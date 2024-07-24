using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportLvl3 : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Nivel 3");
        }
    }
}
