using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score; //texto que contiene la puntuacion
    public TextMeshProUGUI lives; //texto que contiene las vidas
    public GameObject lose; //contiene la ventana de reset
    private void Update()
    {
        score.text = "Score " + LevelManager.instance.score.ToString();//muestra los puntos en la UI
        lives.text = "lives " + LevelManager.instance.playerLives.ToString(); //muestra las vidas en la UI
        lose.SetActive(LevelManager.instance.dead); //activa el reset si moris
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);//permite cargar scene por ID esta id se puede ver en el build setings
    }
}
