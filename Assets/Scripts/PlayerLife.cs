using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //compramos si choca con la trampa
        if (collision.gameObject.CompareTag("Trap"))
            //si choca,muere D:
            Die();
    }  

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static; //en el momento de morir se vuelve static y no podemos controlar el jugador
        anim.SetTrigger("death");
    }

    //recargar el nivel una vez morimos
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
