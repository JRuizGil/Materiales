using UnityEngine;
using UnityEngine.SceneManagement;

public class Hoyo : MonoBehaviour
{
    public GameManager gameManager; // Referencia al GameManager que gestiona el juego

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("¡Pelota en el hoyo!");
            gameManager.SiguienteHoyo();
        }
    }
}

