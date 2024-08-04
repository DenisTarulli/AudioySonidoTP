using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 50f;
    [SerializeField] private float sensitivityMultiplier;

    [SerializeField] private Transform playerBody;

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * sensitivityMultiplier * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * sensitivityMultiplier * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(1.2f * mouseX * Vector3.up);
    }
}
