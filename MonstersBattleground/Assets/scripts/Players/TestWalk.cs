using UnityEngine;

public class TestWalk : MonoBehaviour
{
    [SerializeField] private float velocidade;

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        Vector3 direcaoMovimento = new Vector3(movimentoHorizontal, 0f, 0f);
        transform.position += direcaoMovimento * velocidade * Time.deltaTime;
    }
}
