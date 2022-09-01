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
    Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        dis = new Vector3(Random.Range(-7, 7), Random.Range(-7, 7));
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
        StartCoroutine(Dont_Move_For_S());
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

    IEnumerator Dont_Move_For_S()
    {
        yield return new WaitForSeconds(0.2f);
        //col.enabled = false;
    }
    void Move()
    {
        if (this.gameObject.CompareTag("Enemy"))
        {
            float f = Random.Range(0, 361);
            dis = new Vector3(-1, 1 * Mathf.Sin(f));
            transform.Translate(speed * Time.deltaTime * dis, Space.World);
        }
        else
        {
            transform.Translate(speed * Time.deltaTime * dis, Space.World);
        }


        //리지드 바디 움직임(끊김)
        //rb.MovePosition(transform.position + speed * Time.deltaTime * dis);
    }
}
