using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int lifes = 3; //Vidas de la nave enemiga
    public float speed = 5; //Velocidad Nave enemiga
    private Vector2 direction; //Define la direccion en la que la nave se desplaza
    private bool changeDirection = true;

    private void Start()
    {
        direction = new Vector2(0,1);//aplicamos una direccion para la izquierda
    }
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);//Mueve la nave constantemente en una direccion 
        //MovePatron();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Proyectil")//comprobamos si colisiona con un misil
        {
            lifes--;//pierde una vida
            Destroy(collision.gameObject); //el misil se destruye 
            if (lifes <= 0)
            {
                Destroy(this.gameObject);//el enemigo no tiene mas vidas y es destruido
                LevelManager.instance.score += 10;//sumamos 10 puntos en nuestro level manager
            }    
        }
    }








    public void MovePatron()
    {
        if (transform.position.y < 3)
        {
            if (changeDirection)
            {
                Debug.Log("Nueva direccion");
                changeDirection = false;
                direction = new Vector3(-0.5f, 1);
            }
        }
        else if(transform.position.y < -3)
        {
            direction = new Vector3(0.5f, 1);
        }
        if (transform.position.y < -4)
            changeDirection = true;
    }
}
