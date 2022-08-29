using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hex_movement : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] bool goRight = true;
    [SerializeField] float speed = 40;
    float startingPos;
    float currentSpeed;
    [SerializeField] float distance=192;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
        startingPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {   

        if (goRight)
        {
            if (transform.position.x < startingPos+distance)
            {
                body.velocity = new Vector2(currentSpeed, body.velocity.y);
            }

            else
            {
                body.velocity = new Vector2(currentSpeed, body.velocity.y);

                if (currentSpeed != -speed) 
                    currentSpeed--;
                else
                    goRight = false;
            }
        }

        if (!goRight)
        {
            if (transform.position.x > startingPos)
            {
                body.velocity = new Vector2(currentSpeed, body.velocity.y);
            }

            else
            {
                currentSpeed++;
                body.velocity = new Vector2(currentSpeed, body.velocity.y);
                if (currentSpeed == speed)
                    goRight = true;
            }
        }
    }
}
