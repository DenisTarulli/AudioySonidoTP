using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpHeight = 7f;

    private float gravity = -15f;
    private Vector3 velocity;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = transform.right * xInput + transform.forward * zInput;

        characterController.Move(moveSpeed * Time.deltaTime * moveDir.normalized);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if (characterController.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
