using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] float sensitivityX = 2f;
    [SerializeField] float sensitivityY = 2f;
    [SerializeField] float minYRotation = -90f;
    [SerializeField] float maxYRotation = 90f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        // Captura a entrada do mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calcula a rotação da câmera
        rotationX += mouseX * sensitivityX;
        rotationY -= mouseY * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minYRotation, maxYRotation);

        // Aplica a rotação à câmera
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }
}
