using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidade de rotação

    void Update()
    {
        // Verifica se a tecla 4 está pressionada
        if (Input.GetKey(KeyCode.Alpha4))
        {
            // Rotaciona o objeto no eixo Y com a velocidade definida
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Verifica se a tecla 5 está pressionada
        if (Input.GetKey(KeyCode.Alpha5))
        {
            // Rotaciona o objeto no eixo Y com a mesma velocidade
            transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
        }
    }
}
