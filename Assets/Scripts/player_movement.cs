
using UnityEngine;

public class player_movement : MonoBehaviour
{
	
	public float movespeed = 5f;
	public Rigidbody2D rb;
	Vector2 movement;
	public Animator animator;
    public float maxStamina = 100;
    public float stamina = 100;
    GameObject StaminaIndicator;
    SpriteRenderer staminaBarColour;

    // Update is called once per frame

    private void Start()
    {
        StaminaIndicator = GameObject.Find("StaminaIndicator");
        staminaBarColour = StaminaIndicator.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
		movement.x = Input.GetAxisRaw("Horizontal"); //Get Horizontal Keys (Left & Right Movement)
		movement.y = Input.GetAxisRaw("Vertical"); // Get Vertical Keys (Up & Down Movement)
		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 1.25) //IF Sprinting using Left Shift
        {
            movespeed = 20f;
            stamina -= 2.5f;
        }
        else //Normal walk speed
        {
            movespeed = 5f;
            if (stamina <= (maxStamina - 1.25) && !(Input.GetKey(KeyCode.LeftShift))) //If Stamina smaller than 100 then regenerate if LShift isn't pressed
            {
                stamina += 5.0f;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) //For Future: Have Stamina Bar turn gold upon collision
    {
        if(collision.gameObject.tag == "StaminaPotion")
        {
            Destroy(collision.gameObject);
            //maxStamina += 20;
            maxStamina = maxStamina * 10f;
            staminaBarColour.color = new Color(255, 223, 0);
        }
    }

    private void FixedUpdate()
	{
        rb.MovePosition(rb.position + movement * (movespeed) * Time.fixedDeltaTime);
        Debug.Log("Stamina: " + stamina);
    }
}
