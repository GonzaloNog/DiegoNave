using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float speed;
    public GameObject fire;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal,moveVertical);

        rb.velocity = movement * speed;
        if(rb.velocity.x == 0 && rb.velocity.y == 0)
            fire.SetActive(false);
        else
            fire.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "borde")
        {
            if(this.transform.position.y < 0)
                this.transform.position = new Vector2(this.transform.position.x, (this.transform.position.y * (-1)) - 1);
            else
                this.transform.position = new Vector2(this.transform.position.x, (this.transform.position.y * (-1)) + 1);
        }
    }
}
