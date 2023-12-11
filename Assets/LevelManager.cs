using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float backGroundSpeed = 1 ;
    private int level = 1;
    private void Awake()
    {
        instance = this;
    }
}
