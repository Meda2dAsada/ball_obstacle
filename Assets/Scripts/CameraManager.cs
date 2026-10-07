using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0f, 2.0f, -4f);
    public float smoothSpeed = 0.125f;
    
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;
    
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        transform.LookAt(target.position); 
    }
}
