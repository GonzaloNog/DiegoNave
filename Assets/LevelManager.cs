using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;//las variables staticas, son variables globales que pueden ser usadas desde cualquier clase 
    public float backGroundSpeed = 1 ;//Multiplica la velocidad base del movimiento del fondo, lo que nos permite aumentar la velocidad del fondo sin ir uno por uno
    private int level = 1;//guarda en que nivel estamos
    public int score = 0;//la variable que guarda los puntos
    public bool dead = false;
    public int playerLives = 3;
    private void Awake()
    {
        instance = this;//define que instance sea una referencia a este mismo bojeto
    }
}
