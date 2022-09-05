using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Border : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<Ast>() != null)
        {
            collision.gameObject.GetComponent<Ast>().dis = Vector2.Reflect(collision.gameObject.GetComponent<Ast>().dis, collision.contacts[0].normal);
        }
        else if (collision.gameObject.GetComponent<Ast_Mini>() != null)
        {
            collision.gameObject.GetComponent<Ast_Mini>().dis = Vector2.Reflect(collision.gameObject.GetComponent<Ast_Mini>().dis, collision.contacts[0].normal);
        }
        else if(collision.gameObject.GetComponent<PowerUp>() != null)
        {
            collision.gameObject.GetComponent<PowerUp>().dis = Vector2.Reflect(collision.gameObject.GetComponent<PowerUp>().dis, collision.contacts[0].normal);
        }
        else
        {

        }

    }
}
