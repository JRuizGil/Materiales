using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject Golf;
    public GameObject Tenis;
    public GameObject GOLF;

    public Transform SpawnPosition;

    private GameObject currentBall; // Referencia a la bola activa

    public void SpawnGolfBall()
    {
        DestroyCurrentBall();
        currentBall = Instantiate(Golf, SpawnPosition.position, Quaternion.identity);
    }

    public void SpawnTenisBall()
    {
        DestroyCurrentBall();
        currentBall = Instantiate(Tenis, SpawnPosition.position, Quaternion.identity);
    }

    public void SpawnGOLFBall()
    {
        DestroyCurrentBall();
        currentBall = Instantiate(GOLF, SpawnPosition.position, Quaternion.identity);
    }

    void DestroyCurrentBall()
    {
        if (currentBall != null)
        {
            Destroy(currentBall);
        }
    }
}
