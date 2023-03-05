using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    //contador
    private int fruit = 0;

    [SerializeField] private Text fruitText;

    //sonido de coger la fruta
    [SerializeField] private AudioSource collectionSoundEffect;


    //recoger items por el jugador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //comprueba si se esta chocando el objeto
        if (collision.gameObject.CompareTag("Melon"))
        {
            // cuando recogemos, suena musica
            collectionSoundEffect.Play();
            //si chocamos con el objeto, lo eliminamos
            Destroy(collision.gameObject);
            //al eliminarlo, sumarle al contador 
            fruit++;
            fruitText.text = "Fruta: " + fruit;
             
        }
    }
}
