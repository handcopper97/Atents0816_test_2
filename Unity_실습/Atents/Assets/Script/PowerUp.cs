using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Vector3 dis = new Vector3(-1, 1);
    public float speed = 3, duringTime = 10f, moveRandom = 1f;
    float counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(switchDir());
        Destroy(this.gameObject, duringTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool IsPlayer = collision.gameObject.CompareTag("Player");
        //플레이어 접촉 시 터짐 여부 = IsPlayer
        if (IsPlayer)
        {
            collision.gameObject.GetComponent<Player>().power++;
            Destroy(this.gameObject);
        }
    }
    void Move()
    {

        transform.Translate(speed * Time.deltaTime * dis, Space.World);
        if (Mathf.Abs(transform.position.y) > 4.5f)
        {
            dis.y *= -1;
            transform.Translate(speed * Time.deltaTime * dis, Space.World);
        }

        //리지드 바디 움직임(끊김)
        //rb.MovePosition(transform.position + speed * Time.deltaTime * dis);
    }
    IEnumerator switchDir()
    {
        int r = 0;
        StartCoroutine(counterPlus());
        while (counter < duringTime)
        {
            yield return new WaitForSeconds(moveRandom);
            r = Random.Range(-1, 2);
            while (r == 0)
            {
                r = Random.Range(-1, 2);
            }



            dis = new Vector3(dis.x, dis.y * r);
            
            //counter += Time.deltaTime;
        }

    }

    IEnumerator counterPlus()
    {
        yield return new WaitForSeconds(duringTime);
        counter = duringTime+1;
    }
}
