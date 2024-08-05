using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpHeight = 7f;
    [SerializeField] private float footstepDelay;

    private float gravity = -15f;
    private Vector3 velocity;
    private CharacterController characterController;

    private Vector3 moveDir;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        InvokeRepeating(nameof(FootstepsSound), 0f, footstepDelay);
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        moveDir = transform.right * xInput + transform.forward * zInput;

        characterController.Move(moveSpeed * Time.deltaTime * moveDir.normalized);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if (characterController.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void FootstepsSound()
    {
        if (moveDir.magnitude == 0f || !characterController.isGrounded) return;

        AkSoundEngine.PostEvent("Play_footsteps", gameObject);
    }
}
