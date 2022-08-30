using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ast : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public Vector3 dis;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + speed * Time.fixedDeltaTime * dis);
    }
}
