using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public CharacterController controller;

    public float speed = 12f;
    float realspeed;
    public float gravity = -19.62f;
    public float jumpHeight = 3f;

    public float mindamage;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float Stamina = 120f;
	[HideInInspector] public float x;
	[HideInInspector] public float y;
    [HideInInspector] float z;

	[HideInInspector] Vector3 velocity;
	[HideInInspector] public bool isGrounded;

    public void ToggleMovement ()
    {
        this.enabled = !this.enabled;
    }

	private void Awake ()
	{
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update ()
    {

        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 axis = new Vector3(x, 0, z);

        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0)
        {
            if (axis.x != 0 || axis.z != 0) {
                axis.z *= 2;
                axis.x *= 2;
                Stamina -= 1 * Time.deltaTime * 20;
                if (Stamina <= 0)
                {
                    Stamina = 0;
                }
            } 
        }
        if (Stamina < 100)
        {
            if (0 == axis.x && 0 == axis.z)
            {
                Stamina += 1 * Time.deltaTime * 20;
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {

                }
                else
                {
                    Stamina += 1 * Time.deltaTime * 10;
                }
            }
        }

        Stamina = Mathf.Clamp(Stamina, 0, 100);

        Vector3 move = transform.right * axis.x + transform.forward * axis.z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
	}
}
