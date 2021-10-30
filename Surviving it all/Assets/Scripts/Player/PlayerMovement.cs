using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int walk_speed;
    [SerializeField] private CharacterController player_controller;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        player_controller.Move(move * walk_speed * Time.deltaTime);
    }
}
