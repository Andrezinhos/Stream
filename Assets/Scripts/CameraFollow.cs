using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 offset = new Vector3(0, 0, -5);
    public float suav = 5;
    public Transform target;

    void LateUpdate()
    {
        Vector3 newPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPos, suav * Time.deltaTime);
    }
}
