using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Ast_Mini : MonoBehaviour
{

    public float speed;
    public Vector3 dis = new Vector3(0,0);
    public int Max_s = 5, score=10;
    public float during_time = 10f;
    // Start is called before the first frame update
    private System.Action<int> onDead;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        
        while ((dis.x ==0&&dis.y==0))
        {
            dis = new Vector3(Random.Range(-Max_s, Max_s), Random.Range(-Max_s, Max_s));
        }


        StartCoroutine(Destroy_timelek(during_time)); 
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
            onDead += player.AddScore;
            onDead(score);
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
    IEnumerator Destroy_timelek(float t)
    {
        yield return new WaitForSeconds(t);
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.transform.parent = null;
        Destroy(this.gameObject);
    }

    void Move()
    {
        
        transform.Translate(speed * Time.deltaTime * dis, Space.World);


        //리지드 바디 움직임(끊김)
        //rb.MovePosition(transform.position + speed * Time.deltaTime * dis);
    }
}
