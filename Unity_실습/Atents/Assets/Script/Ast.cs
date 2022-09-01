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
    int counter;
    float r, rotationSpeed;
    SpriteRenderer sp;
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 10f);





        if (this.gameObject.CompareTag("Ast"))
        {

            //스피드 랜덤
            speed = Random.Range(2, 5);

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
                rotationSpeed = 0.5f;

            }
            StartCoroutine(Auto_Explosion());


        }
    }
    IEnumerator Auto_Explosion()
    {
        float r = Random.Range(3f, 6f);
        yield return new WaitForSeconds(r);

        Explosion();

    }
    // Update is called once per frame
    void Update()
    {

        rb.MovePosition(transform.position + speed * Time.deltaTime * dis);
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
        if (transform.childCount>=1)
        {
            if (this.gameObject.CompareTag("Ast"))
            {

                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);

                }
                for (int i = 0; i <transform.childCount;)
                {
                    transform.GetChild(i).gameObject.transform.parent = null;

                }

                Destroy(this.gameObject);


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

}
