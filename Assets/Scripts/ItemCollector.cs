using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    //contador
    private int melons = 0;

    [SerializeField] private Text melonsText;

    //recoger items por el jugador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //comprueba si se esta chocando el objeto
        if (collision.gameObject.CompareTag("Melon"))
        {
            //si chocamos con el objeto, lo eliminamos
            Destroy(collision.gameObject);
            //al eliminarlo, sumarle al contador 
            melons++;
            melonsText.text = "Melones : " + melons;
             
        }
    }
}
