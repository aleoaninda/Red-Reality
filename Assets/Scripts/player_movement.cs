
using UnityEngine;
using System;
using System.Threading.Tasks;
using System.Timers;
using UnityEditor;
using UnityEngine.UI;


public class player_movement : MonoBehaviour
{
    //public Text Counter1;
    
    public float movespeed = 5f;
	public Rigidbody2D rb;
	public Vector2 movement;
	public Animator animator;
    public float maxStamina = 100;
    public float stamina = 100;
    GameObject StaminaIndicator;
    //GameObject gameOver;
    SpriteRenderer staminaBarColour;
    private Timer timer;
    bool isTimerOn = false;
    bool isValidTimer = false;
    bool isExit = false;
    public Image gameOver;
    public Text counter123;
    public float timerCounter = 0.0f;
    public int seconds;
    public int randomNumber;
    public GameObject redzonescale;
    private bool isActiveTimerPosition = false;



    // Update is called once per frame

    private void Start()
    {

        
        //gameOver.GetComponent<Renderer>().enabled = true;
        //Debug.Log(">>>>>>>>>>>>Start");
        StaminaIndicator = GameObject.Find("StaminaIndicator");
        staminaBarColour = StaminaIndicator.GetComponent<SpriteRenderer>();
        // gameOver = GameObject.Find("gameover");
        // gameOver.GetComponent<Renderer>().enabled = false;
         //gameOver.enabled = false;
         gameOver.enabled = false;
         counter123.enabled = false;
    }

    void Update()
    {
        if (isExit == true)
        {
            //gameOver.enabled = true;
            gameOver.enabled = true;
            counter123.enabled = false;
            return;

        }    
        //Debug.Log(">>>>>>>>>>>>Update");
        //gameOver.enabled = false;
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
        // System.Diagnostics.Debug.log(">>>>>>>>>>>>" + movement.y);
        //Debug.Log(">>>>>>>>>>>>" + movement.x);
        
        if(isValidTimer)
        {
            timerCounter += Time.deltaTime;
            // turn seconds in float to int
            seconds = (randomNumber/1000) - (int)(timerCounter % 60);
            Debug.Log("<<<<<<<<<<<<<<<<<<Couner" + seconds);
            counter123.enabled = true;
            counter123.text = Convert.ToString(seconds);
            
            //gameOver.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            timerCounter = 0;
            counter123.enabled = false;
        }
           

    }

    private void OnCollisionEnter2D(Collision2D collision) //For Future: Have Stamina Bar turn gold upon collision
    {
        Debug.Log(">>>>>>>>>>>>OnCollisionEnter2D"+ collision.gameObject.tag);
        if (collision.gameObject.tag == "StaminaPotion")
        {
            Destroy(collision.gameObject);
            //maxStamina += 20;
            maxStamina = maxStamina * 10f;
            staminaBarColour.color = new Color(255, 223, 0);
            Debug.Log(">>>>>>>>>>>>StaminaPotion");
        }
        
    }

    private void FixedUpdate()
	{
        if (isExit)
            return;
        //Debug.Log(">>>>>>>>>>>>FixedUpdate");
        rb.MovePosition(rb.position + movement * (movespeed) * Time.fixedDeltaTime);
        Debug.Log(">>>>>>>>>>>>> position X : " + rb.position.x +" Y " + rb.position.y);
        //Debug.Log("Stamina Y: " + rb.position.y);
        // Debug.Log(">>>>>>>>>>>>>"+gameObject.name);

        redzonescale = GameObject.Find("RedZone");
        Debug.Log(">>>>>>>>>>>>> position XP : " + redzonescale.transform.localScale.x + " YP " + redzonescale.transform.localScale.y);
        if (redzonescale.transform.localScale.x == 4)
        {
            // isValidTimer = true;
            if (rb.position.x < -7.0 || rb.position.x > 7.0 || rb.position.y < -5.5 || rb.position.y > 8.0)
            {
                isValidTimer = true;

                if (!isTimerOn)
                {


                    System.Random rnd = new System.Random();
                    randomNumber = rnd.Next(3000, 7000);

                    Debug.Log(">>>>>>>>>>>>timerStart");
                    timer = new Timer(randomNumber);
                    timer.Elapsed += async (sender, e) => await HandleTimer();
                    timer.Start();
                    //timer.Stop();

                    isTimerOn = true;


                }


            }
            else
            {
                isValidTimer = false;
                timer.Stop();
                isTimerOn = false;
            }

        }

        else if (redzonescale.transform.localScale.x > 8 && redzonescale.transform.localScale.x < 12.4)
        {
            // isValidTimer = true;
            if (rb.position.x < -14.0 || rb.position.x > 14.0 || rb.position.y < -13.0 || rb.position.y > 15.0)
            {
                isValidTimer = true;

                if (!isTimerOn)
                {


                    System.Random rnd = new System.Random();
                    randomNumber = rnd.Next(3000, 7000);

                    Debug.Log(">>>>>>>>>>>>timerStart");
                    timer = new Timer(randomNumber);
                    timer.Elapsed += async (sender, e) => await HandleTimer();
                    timer.Start();
                    //timer.Stop();

                    isTimerOn = true;


                }


            }
            else
            {
                isValidTimer = false;
                timer.Stop();
                isTimerOn = false;
            }

        }

        else if (redzonescale.transform.localScale.x > 12.4 && redzonescale.transform.localScale.x < 17.4)
        {
            // isValidTimer = true;
            if (rb.position.x < -21.0 || rb.position.x > 21.50 || rb.position.y < -20.5 || rb.position.y > 22.0)
            {
                isValidTimer = true;

                if (!isTimerOn)
                {


                    System.Random rnd = new System.Random();
                    randomNumber = rnd.Next(3000, 7000);

                    Debug.Log(">>>>>>>>>>>>timerStart");
                    timer = new Timer(randomNumber);
                    timer.Elapsed += async (sender, e) => await HandleTimer();
                    timer.Start();
                    //timer.Stop();

                    isTimerOn = true;


                }


            }
            else
            {
                isValidTimer = false;
                timer.Stop();
                isTimerOn = false;
            }

        }

        else if (redzonescale.transform.localScale.x > 17.4 && redzonescale.transform.localScale.x < 21.5)
        {
            // isValidTimer = true;
            if (rb.position.x < -29.0 || rb.position.x > 30.0 || rb.position.y < -28.5 || rb.position.y > 30.0)
            {
                isValidTimer = true;

                if (!isTimerOn)
                {


                    System.Random rnd = new System.Random();
                    randomNumber = rnd.Next(3000, 7000);

                    Debug.Log(">>>>>>>>>>>>timerStart");
                    timer = new Timer(randomNumber);
                    timer.Elapsed += async (sender, e) => await HandleTimer();
                    timer.Start();
                    //timer.Stop();

                    isTimerOn = true;


                }


            }
            else
            {
                isValidTimer = false;
                timer.Stop();
                isTimerOn = false;
            }

        }

        else if (redzonescale.transform.localScale.x > 21.5)
        {
            // isValidTimer = true;
            if (rb.position.x < -37.0 || rb.position.x > 36.0 || rb.position.y < -37.5 || rb.position.y > 38.0)
            {
                isValidTimer = true;

                if (!isTimerOn)
                {


                    System.Random rnd = new System.Random();
                    randomNumber = rnd.Next(3000, 7000);

                    Debug.Log(">>>>>>>>>>>>timerStart");
                    timer = new Timer(randomNumber);
                    timer.Elapsed += async (sender, e) => await HandleTimer();
                    timer.Start();
                    //timer.Stop();

                    isTimerOn = true;


                }


            }
            else
            {
                isValidTimer = false;
                timer.Stop();
                isTimerOn = false;
            }

        }
    }

    private Task HandleTimer()
    {
        Debug.Log(">>>>>>>>>>>>timer stoped...");
        if (isValidTimer)
        {
           // gameOver.text = "GAME OVER!!";
            Debug.Log(">>>>>>>>>>>>timer stoped...");
            Debug.Log("Game Over!!");
            
            timer.Stop();
          //  gameOver.enabled = true;
            isExit = true;
          //  gameOver.enabled = true;
            //gameOver.text = "GAME OVER";
            throw new NotImplementedException();
            //timer.Stop();
        }
        else
        {
            Debug.Log(">>>>>>>>>>>>timer stoped...");
            //Debug.Log("Game Over!!");
            timer.Stop();
            isTimerOn = false;
            //isExit = true;
            throw new NotImplementedException();
            //timer.Stop();
        }

        

    }


}
