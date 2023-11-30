using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivityX = 100f;
    [SerializeField] private float sensitivityY = 100f;

    private float mouseX;
    private float mouseY;

    private float yRotation;
    private float xRotation;

    [SerializeField] private Transform player;
    [SerializeField] private float minXRotation = -90f;
    [SerializeField] private float maxXRotation = 90f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        yRotation += mouseX * Time.deltaTime;
        xRotation -= mouseY * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, minXRotation, maxXRotation);

        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, 0.1f);

        player.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
