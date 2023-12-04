using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float startPoint;
    public float endPoint;
    public float speed;
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x - (speed * Time.deltaTime), this.transform.position.y);
        if (this.transform.position.x < endPoint)
            restart();
    }

    void restart()
    {
        this.transform.position = new Vector2(startPoint, this.transform.position.y);
    }
}
