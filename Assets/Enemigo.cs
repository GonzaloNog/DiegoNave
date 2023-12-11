using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int lifes = 3;
    public float speed = 5;
    private Vector2 direction;
    private bool changeDirection = true;

    private void Start()
    {
        direction = new Vector2(0,1);
    }
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if(transform.position.y < 4 && changeDirection)
        {
            changeDirection = false;
            direction = new Vector2(-0.5f, 1);
        }
        else
        {
            direction = new Vector2(0.5f, 1);
        }
        if(transform.position.y < -4)
            changeDirection = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Proyectil")
        {
            Debug.Log("Impacto");
            lifes--;
            Destroy(collision.gameObject);
            if (lifes <= 0)
                Destroy(this.gameObject);
        }
    }
}
