using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f; 
    public Vector3 offset;
    public float minY;

    void LateUpdate()
    {
    
        if (target != null )
        {
            Vector3 desiredPosition = target.position  + offset;

            if (desiredPosition.y < minY)
            {
                desiredPosition.y = minY;
            }

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }
}
