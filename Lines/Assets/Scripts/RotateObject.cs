using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [Header("Extra Rotations")]
    public float xRotationSpeed = 30f;
    public float yRotationSpeed = 30f;

    void Update()
    {
        transform.Rotate(
            xRotationSpeed * Time.deltaTime,
            yRotationSpeed * Time.deltaTime,
            0f,
            Space.Self
        );
    }
}
