using UnityEngine;

public class Ball : MonoBehaviour
{
    public float launchForce = 500f; // Fuerza de lanzamiento
    private bool isSelected = false;
    private Rigidbody rb;
    private Camera mainCamera;
    public Transform Startpos;

    public float rotationSpeed = 100f; // Velocidad de giro de la bola
    public float cameraDistance = 5f;  // Distancia de la cámara a la bola
    public float cameraHeight = 2f;    // Altura de la cámara sobre la bola

    private float currentCameraAngle = 0f;

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
            OrbitCameraAroundBall();
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
                Debug.Log("Bola deseleccionada (clic en otro objeto)");
            }
        }
        else
        {
            isSelected = false;
            Debug.Log("Bola deseleccionada (clic en vacío)");
        }
    }
    void RotateBallWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        currentCameraAngle += mouseX * rotationSpeed * Time.deltaTime;
    }
    void OrbitCameraAroundBall()
    {
        Vector3 offset = new Vector3(
            Mathf.Sin(currentCameraAngle * Mathf.Deg2Rad),
            0,
            Mathf.Cos(currentCameraAngle * Mathf.Deg2Rad)
        ) * cameraDistance;

        Vector3 cameraPosition = transform.position + offset + Vector3.up * cameraHeight;
        mainCamera.transform.position = cameraPosition;
        mainCamera.transform.LookAt(transform.position + Vector3.up * 1f); // Mira hacia la bola
    }
    void LaunchBall()
    {
        Vector3 launchDirection = (transform.position - mainCamera.transform.position).normalized;
        rb.AddForce(launchDirection * launchForce);
        // isSelected = false;
        Debug.Log("Bola lanzada");
    }
}
