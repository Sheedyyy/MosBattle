using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
     [SerializeField] private float _moveSpeed;

    void Update()
    {
        // Captura a entrada do teclado
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Cria um vetor de movimento
        Vector3 move = new Vector3(moveX, 0, moveZ) * _moveSpeed * Time.deltaTime;

        // Aplica o movimento ao personagem
        transform.Translate(move, Space.World);
    }
}
