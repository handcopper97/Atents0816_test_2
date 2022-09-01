using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Ast_Mini : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    public Vector3 dis;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dis = new Vector3(Random.Range(-7, 7), Random.Range(-7, 7));
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + speed * Time.deltaTime * dis);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool IsPlayer = collision.gameObject.CompareTag("Player");
        //플레이어 접촉 시 터짐 여부 = IsPlayer
        if (collision.gameObject.CompareTag("Bullet") || IsPlayer)
        {
            Explosion();
        }
    }

    void Explosion()
    {
        if (transform.childCount >= 1)
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
