using UnityEngine;
/// &lt;summary&gt;
/// Smoothly follows the target (player) in a 2D platformer style.
/// Camera is orthographic and keeps fixed Z offset.
/// &lt;/summary&gt;
public class CameraFollow2D : MonoBehaviour
{
    [Tooltip("Target to follow, e.g. player transform")]
    public Transform target;
    [Tooltip("Offset from the target position")]
    public Vector3 offset = new Vector3(0f, 1.5f, -10f);
    [Tooltip("Smooth time for movement")]
    public float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;
    void LateUpdate()
    {
        if (target == null)
            return;
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = smoothPosition;
    }
}