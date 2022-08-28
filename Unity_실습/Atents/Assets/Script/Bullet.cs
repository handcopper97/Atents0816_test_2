using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1;
    public Vector3 inputDir = new Vector3(1,0,0);
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + speed * Time.fixedDeltaTime * inputDir);
    }
}
