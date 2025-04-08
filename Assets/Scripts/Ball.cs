using UnityEngine;

public class Ball : MonoBehaviour
{
    public float launchForce = 500f; // Fuerza de lanzamiento
    private bool isSelected = false;
    private Rigidbody rb;
    private Camera mainCamera;
    public Transform Startpos;

    public float rotationSpeed = 100f; // Velocidad de giro de la bola

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;

        if (Startpos != null)
            mainCamera.transform.position = Startpos.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectBall();
        }

        if (isSelected)
        {
            RotateBallWithMouse();
        }

        if (isSelected && Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }
    }

    void SelectBall()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                isSelected = true;
                Debug.Log("Bola seleccionada");
            }
            else
            {
                isSelected = false;
            }
        }
    }

    void RotateBallWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);
    }

    void LaunchBall()
    {
        rb.AddForce(mainCamera.transform.forward * launchForce);
        isSelected = false;
        Debug.Log("Bola lanzada");
    }
}
