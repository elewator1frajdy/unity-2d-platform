using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject staminaBar;
    health heatlhbar_Script;
    stamina staminabar_Script;

    [SerializeField] float speed = 40;
    float currentSpeed;
    [SerializeField] float jump_heist = 40;
    float currentJumpHeist;

    float tempDirection = 0;
    float currentPos;
    float previousPos;

    bool isGrounded;
    [SerializeField] bool isStuck;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
        currentJumpHeist = jump_heist;

        heatlhbar_Script = healthBar.GetComponent<health>();
        staminabar_Script = staminaBar.GetComponent<stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position.x;

        if (currentPos == previousPos)
            isStuck = true;
        else
            isStuck = false;

        if (!isStuck && body.velocity.y == 0)
            isGrounded = true;
        else
            isGrounded = false;

        previousPos = currentPos;

        //running
        tempDirection = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(tempDirection * currentSpeed, body.velocity.y);


        //jumping
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, currentJumpHeist);

        }


        //accelerating & increasing jump heist
        
        if ((tempDirection== 1 || tempDirection==-1) && currentSpeed < (3 * speed))
        {
            currentSpeed += (float)0.5;
            currentJumpHeist += (float)0.5;
        }
            
        else if(tempDirection < 1 && tempDirection > -1)
        {
            currentSpeed = speed;
            currentJumpHeist = jump_heist;
        }

        if (body.velocity.x == 0)
        {
            if (staminabar_Script.slider.value == 0)
                heatlhbar_Script.takeDamage((float)0.2);
            else
                staminabar_Script.loseStamina();
        }
        else
            staminabar_Script.setMaxStamina();
    }
}
