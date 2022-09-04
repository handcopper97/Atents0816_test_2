using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Ast_Mini : MonoBehaviour
{

    public float speed;
    public Vector3 dis = new Vector3(0,0);
    public float Max_s = 7f, Min_s = 3f;
    Collider2D col;
    Ast_Mini ast_m;
    // Start is called before the first frame update
    void Start()
    {
        while((dis.x ==0&&dis.y==0))
        {
            dis = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10));
        }
        
        
        Destroy(this.gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void OnEnable()
    {
        //col.enabled = true;
        //ast_m.enabled = true;
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

    
    void Move()
    {
        
        transform.Translate(speed * Time.deltaTime * dis, Space.World);


        //리지드 바디 움직임(끊김)
        //rb.MovePosition(transform.position + speed * Time.deltaTime * dis);
    }
}
