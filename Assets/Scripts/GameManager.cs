using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] hoyos; // Lista de hoyos en orden
    public GameObject pelota; // Referencia a la bola
    private int hoyoActual = 0;
    private int tiros = 0;

    void Start()
    {
        ActivarHoyoActual();
    }

    public void ContarTiro()
    {
        tiros++;
        Debug.Log("Tiro n�mero: " + tiros);
    }

    public void SiguienteHoyo()
    {
        Debug.Log("Hoyo " + (hoyoActual + 1) + " completado con " + tiros + " tiros.");

        // Desactivar hoyo actual
        hoyos[hoyoActual].SetActive(false);

        // Ir al siguiente
        hoyoActual++;

        if (hoyoActual >= hoyos.Length)
        {
            Debug.Log("�Has terminado todos los hoyos!");
            // Aqu� podr�as cargar una escena de final o reiniciar
        }
        else
        {
            tiros = 0; // Reset de tiros
            ActivarHoyoActual();
            ReiniciarPelota(); // Si deseas volver a colocar la bola al principio
        }
    }

    void ActivarHoyoActual()
    {
        hoyos[hoyoActual].SetActive(true);
    }

    void ReiniciarPelota()
    {
        pelota.transform.position = new Vector3(0, 1, 0); // Puedes ajustar esta posici�n seg�n tu mapa
        Rigidbody rb = pelota.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
