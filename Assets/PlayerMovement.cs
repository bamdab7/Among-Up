using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    //int wholeNumber = 16;
    //float decimalNumber = 4.54f;
    //string text = "default text";
    //bool boolean = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //trabajamos con los movimientos laterales
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7f,rb.velocity.y);

        if(Input.GetButtonDown("Jump")) //solo se ejecuta si pulsamos, no si mantenemos
        {
            //hara que nuestro jugador salte
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }

    }
}
