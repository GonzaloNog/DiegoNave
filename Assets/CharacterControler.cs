using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float speed; //controla la velocidad de la nave
    public float lifePoints = 100.0f; //puntos de vida de nuestra nave
    public GameObject fire; //sprite de fuego para la nave en movimiento
    private Rigidbody2D rb; //variable para guardad una referencia al rigidbody2D de nuestro personaje
    private bool life = true;//variable que determina si nuestra nave sigue viva o fue destruida

    //Misil
    public GameObject shoot;//posicion desde donde sale el misil
    public GameObject misilPrefab;//prefad del misil para generar
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//buscamos dentro de nuestro objeto un componente de tipo "Rigidbody2D" y la guardamos en nuestra variable
        fire.SetActive(false);//como la nave arranca apagada queremos que ni bien se ejecute el script el fuego este apagado
    }

    // Update is called once per frame
    void Update()
    {
        if (life)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");//ingresa la informacion de los input Horizontal entre -1 y 1 (0 si ninguna tencla esta precionada)
            float moveVertical = Input.GetAxis("Vertical");//ingresa la informacion de los input Vertical entre -1 y 1 (0 si ninguna tencla esta precionada)

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);//creamos un vector 2 usando las dos funciones creadas anteriormente, para determinar una direccion en un plano 2d 

            rb.velocity = movement * speed;//aplicamos una veocidad a nuestro objeto, hacia una direccion fija * la velocidad en nuestra variable speed
            if (rb.velocity.x == 0 && rb.velocity.y == 0)//este if determina si tenemos que mostrar el sprite del fuego de la nave, para esto comprobamos si se esta moviendo en alguna direccion
                fire.SetActive(false);//fuego apagado
            else
                fire.SetActive(true);//fuego prendido

            //Misil
            if (Input.GetKeyDown(KeyCode.Space))//cuando apretamos la tecla spacio sale disparado el misil
            {
                GameObject newProjectil = Instantiate(misilPrefab, shoot.transform.position, shoot.transform.rotation);//se genera un misil, pasamos el prefad, la posicion y la rotacion
            }
        }
    }

    public void setLifePoints(float points)//esta funcion va a modificar los puntos de vida de la nave y determinar si fue o no destruida
    {
        lifePoints += points;//sumamos los puntos pasados a nuestra variable de vida
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "borde")//comprobamos que el tag del objeto contra el que colisionamos, sea un borde del scenario
        {
            if(this.transform.position.y < 0)//si la posicion en Y es menor a 0 significa que estamos colicionando con el borde inferior y que queremos aparecer en la aprte superior, si no, se ejecuta lo opuesto
                this.transform.position = new Vector3(this.transform.position.x, (this.transform.position.y * (-1)) - 1, this.transform.position.z);
            else
                this.transform.position = new Vector3(this.transform.position.x, (this.transform.position.y * (-1)) + 1, this.transform.position.z);
        }
        if(collision.gameObject.tag == "enemigo")
        {
            life = false;
            Destroy(collision.gameObject);
        }
    }
}
