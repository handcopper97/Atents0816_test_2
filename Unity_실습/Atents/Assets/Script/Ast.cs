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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.MovePosition(transform.position + speed * Time.deltaTime * dis);
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("Ast"))
            {
                counter++;
                if (counter >= 3)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(0).gameObject.transform.parent = null;
                    Destroy(this.gameObject);

                }
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.transform.parent = null;
                Destroy(this.gameObject);
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
   
}
