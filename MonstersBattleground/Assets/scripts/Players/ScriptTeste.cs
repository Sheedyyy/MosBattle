using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTeste : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0, moveY);
        controller.Move(moveDirection * Time.deltaTime * playerSpeed);
    }

}
