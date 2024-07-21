using UnityEngine;

public class FLCameraController : MonoBehaviour
{
    public Transform target;
    public float distance;
    public float xSpeed;
    public float ySpeed;
    public float damping; // Damping factor for smooth camera movement

    private float x = 0.0f;
    private float y = 0.0f;

    public float maxY;
    public float minY;

    public bool isLocked;

    void Start()
    {
        x = target.rotation.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (Input.touchCount == 1 && !isLocked)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Check if the touch is in the top half of the screen
            if (Input.GetTouch(0).position.y > 300)
            {
                // Adjust x and y angles based on touch input
                x += touchDeltaPosition.x * xSpeed * distance * 0.002f;
                y -= touchDeltaPosition.y * ySpeed * 0.002f;
            }
        }

        // Clamp the vertical angle to prevent flipping
        y = Mathf.Clamp(y, minY, maxY);

        // Smoothly interpolate towards the target rotation and position
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 targetPosition = target.position + rotation * new Vector3(0.0f, 0.0f, -distance);

        // Apply damping to the camera movement
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * damping);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    public void SwitchLockedPosition(Transform target){
        this.target = target;
        // Rotates the camera on y axis to match the target's rotation
        x = target.rotation.eulerAngles.y;
    }
}
