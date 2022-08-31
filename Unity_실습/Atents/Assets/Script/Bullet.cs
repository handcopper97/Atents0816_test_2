using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1;
    public Vector3 inputDir = new Vector3(1, 0, 0);
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Destroy(this.gameObject, 7f);

    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + speed * Time.fixedDeltaTime * inputDir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")|| collision.gameObject.CompareTag("Ast"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.transform.parent = null;
            Destroy(this.gameObject);
        }
        else
        {

        }
            
    }
}
