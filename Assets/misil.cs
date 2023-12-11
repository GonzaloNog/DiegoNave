using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misil : MonoBehaviour
{
    public float speed = 5;//Esta variable va a controlar la velocidad a la que viaja el misil
    public Vector2 direction;//nuestro Vector2 direccion nos va a permitir indicar en que direccion queremos que viaje el misil
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);//Translate lo que hace es mover nuestro objeto en una direccion fija, para eso lo multiplicamos por la speed y por el time delta time para que se vea siempre igual
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
