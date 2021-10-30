using UnityEngine;

public class PlayerCameraLook : MonoBehaviour
{
    [SerializeField] private Transform player_transform;
    [Range(40, 100)] [SerializeField] private float mouse_sensetivity;

    private float camera_x_rotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X") * mouse_sensetivity * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * mouse_sensetivity * Time.deltaTime;

        camera_x_rotation -= mouse_y;
        camera_x_rotation = Mathf.Clamp(camera_x_rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(camera_x_rotation, 0f, 0f);
        player_transform.Rotate(Vector3.up * mouse_x);
    }
}
