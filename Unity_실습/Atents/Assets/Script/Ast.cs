using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Ast : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public Vector3 dis;
    int counter = 0;
    float r, sum;
    SpriteRenderer sp;


    public float rotateSpeed = 360.0f;          // 회전 속도
    public float moveSpeed = 3.0f;              // 이동 속도

    public float minMoveSpeed = 2.0f;
    public float maxMoveSpeed = 4.0f;
    public float minRotateSpeed = 30.0f;
    public float maxRotateSpeed = 360.0f;


    // Start is called before the first frame update
    void Start()
    {
        SetStart();
        
        if (this.gameObject.CompareTag("Ast"))
        {
            SetAst();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

        Move();

    }

    void SetStart()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 10f);

    }
    void Rotate()
    {
        if (this.gameObject.CompareTag("Ast"))
        {
            transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);   // Vector3.forward 축을 기준으로 1초에 rotateSpeed도씩 회전
        }

        //랜덤 회전 시도(실패, nt)
        /*
        if (this.gameObject.CompareTag("Ast"))
        {
            //회전 랜덤

            rotation = Quaternion.LookRotation(transform.position - new Vector3(0,0,0), Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        }
        */
    }

    void Move()
    {
        if (this.gameObject.CompareTag("Enemy"))
        {
            float f=0;
            sum += Time.deltaTime*3f;
            /*
            if (0.5f < sum)

            {
                f = Random.Range(0, 361);
                sum -= sum;

            }*/
            dis = new Vector3(-1, 1.5f * Mathf.Sin(sum));


            transform.Translate(speed * Time.deltaTime * dis, Space.World);
        }
        else
        {
            transform.Translate(speed * Time.deltaTime * dis, Space.World);
        }


        //리지드 바디 움직임(끊김)
        //rb.MovePosition(transform.position + speed * Time.deltaTime * dis);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool IsPlayer = collision.gameObject.CompareTag("Player");
        //플레이어 접촉 시 터짐 여부 = IsPlayer
        if (collision.gameObject.CompareTag("Bullet") || IsPlayer)
        {
            if (this.gameObject.CompareTag("Ast"))
            {
                counter++;
                if (counter >= 3 || IsPlayer)
                {
                    Explosion();


                }
            }
            else
            {
                Explosion();
            }

            //
            //Destroy(this.gameObject, ani.GetCurrentAnimatorClipInfo(0)[0].clip.length);
            //ani.
            //Debug.Log($"{ani.GetCurrentAnimatorClipInfo(0)[0].clip.length}, {ani.GetCurrentAnimatorClipInfo(1)[0].clip.name}");
            //GetComponent<SpriteRenderer>().enabled = false;
            //stop = true;
            //Destroy(this.gameObject, 1f);
        }
    }

    void Explosion()
    {
        if (transform.childCount >= 1)
        {

            if (this.gameObject.CompareTag("Ast"))
            {
                Crush();
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.transform.parent = null;
                Destroy(this.gameObject);
            }


        }
        else
        {

        }
    }

    void Crush()
    {
        //랜덤 o
        int rand = Random.Range(0, transform.childCount);
        for (int i = 0; i < transform.childCount - rand; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);

        }
        for (int i = 0; i < transform.childCount - rand;)
        {
            transform.GetChild(i).gameObject.transform.parent = null;

        }

        Destroy(this.gameObject);


        //랜덤 트라이(작동안됨, 배열 에러)
        /*
        int rand = Random.Range(1, transform.childCount);
        for (int i = 0; i <= rand;)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(i).gameObject.transform.parent = null;

        }
        Destroy(this.gameObject);
        */
    }

    void SetAst()
    {
        //스피드 랜덤
        speed = Random.Range(1, 3) / 1.5f;

        //축 랜덤
        r = Random.Range(0, 3);
        if (r == 0)
        {
            sp.flipX = true;
        }
        else if (r == 1)
        {
            sp.flipY = true;
        }
        else
        {
            sp.flipX = true;
            sp.flipY = true;

            //회전 랜덤
            moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
            float ratio;
            if (speed == minMoveSpeed)
            {
                ratio = 0;
            }
            else
            {
                ratio = (speed - minMoveSpeed) / (maxMoveSpeed - minMoveSpeed);
            }

            rotateSpeed = ratio * (maxRotateSpeed - minRotateSpeed) + minRotateSpeed;

        }
        StartCoroutine(Auto_Explosion());
    }

    IEnumerator Auto_Explosion()
    {
        float r = Random.Range(3f, 6f);
        yield return new WaitForSeconds(r);

        Explosion();

    }
}
