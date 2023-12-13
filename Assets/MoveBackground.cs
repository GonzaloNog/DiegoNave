using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float startPoint;//Definimos el punto de inicio de nuestro fondo
    public float endPoint;//definimos el punto de fin de nuestro fondo
    public float speed;//definimos la velocidad en la que queremos que se mueva el fondo

    void Update()
    { 
        this.transform.position = new Vector2(this.transform.position.x - ((speed * LevelManager.instance.backGroundSpeed) * Time.deltaTime), this.transform.position.y);//movemos en cada frame la imagen en direccion x, se usa TimeDeltaTime, para que se mueva a la misma velocidad siempre indistintamente de la PC
        if (this.transform.position.x < endPoint)//si su posicion es menor a la posicion de endPoint reseteamos el fondo 
            restart();
    }

    void restart()
    {
        this.transform.position = new Vector2(startPoint, this.transform.position.y);//reseteamos la posicion X de la imagen con el startPoint 
    }
}
