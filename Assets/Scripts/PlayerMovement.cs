using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    //referirmos al animator de movimiento para trabajar con el booleano
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX = 0f;

    //se muestran en el editor para que asi se puedan modificar
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle,running,jumping,falling }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //trabajamos con los movimientos laterales
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump")) //solo se ejecuta si pulsamos, no si mantenemos
        {
            //hara que nuestro jugador salte
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
    //control de animaciones de movimiento del jugador
        if(dirX  > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle; 
        }
        //animacion de salto
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
