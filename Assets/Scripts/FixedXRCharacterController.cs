using UnityEngine;

public class FixXRTransform : MonoBehaviour
{
    [Header("Fixed Y Position")]
    public float fixedY = -0.41f;

    [Header("Fixed Rotation")]
    public Vector3 fixedRotation = new Vector3(0f, 90f, 0f);

    private void LateUpdate()
    {
        // Keep Y position fixed
        Vector3 position = transform.position;
        position.y = fixedY;
        transform.position = position;

        // Keep rotation fixed
        transform.rotation = Quaternion.Euler(fixedRotation);
    }
}