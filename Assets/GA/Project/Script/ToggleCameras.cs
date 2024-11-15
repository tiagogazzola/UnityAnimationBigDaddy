using UnityEngine;

public class ToggleCameras : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    void Start()
    {
        // Desativa todos os objetos no início
        object1.SetActive(true);
        object2.SetActive(false);
        object3.SetActive(false);
    }

    void Update()
    {
        // Verifica qual tecla foi pressionada e ativa apenas o objeto correspondente
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleObject(object1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleObject(object2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToggleObject(object3);
        }
    }

    void ToggleObject(GameObject objToActivate)
    {
        // Desativa todos os objetos
        object1.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(false);

        // Ativa o objeto especificado
        objToActivate.SetActive(true);
    }
}
