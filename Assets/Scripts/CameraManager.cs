using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed;

    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
