using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject enemyPrefad; //Guardamos el prefad del enemigo para spawnearlo
    public float timeSpawn = 1; //tiempo que tiene que pasar entre la salida de un enemigo nuevo y otro
    private float time = 0; //la usamos para controlar el tiempo trascurrido

    private void Start()
    {
        time = timeSpawn;//tiem tiene que vale rlo mismo que time spawn apra arrancar a contar el tiempo
    }
    void Update()
    {
        time -= Time.deltaTime;//vamos restando el tiempo trascurrido a time para que cuando este en 0 spawne una nave nueva
        if(time <= 0)
        {
            Instantiate(enemyPrefad, new Vector3(transform.position.x, Random.Range(-4f, 4f), -3), transform.rotation);//creamos una nave nueva con una posicion random en el eje Y 
            time = timeSpawn;//reseteamos el time para esperar por otro spawn
        }

    }
}
