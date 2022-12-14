using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Avoid : MonoBehaviour
{
    public GameObject Bullet;
    public float speed = 1f;
    PlayerInputAction inputActions;
    Rigidbody2D rigid;
    float r;
    int dis = 1;
    float sum = 0f;
    Animator ani;
    bool stop;
    // Start is called before the first frame update
    void Awake()
    {
        ani = GetComponent<Animator>();
        r = Random.Range(0, 16.8f) - 8.4f;
        //inputActions = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>();
        inputActions = new PlayerInputAction();
    }
    void FixedUpdate()
    {
        sum += Time.deltaTime;
        if (sum > dis)
        {
            r = Random.Range(0, 16.8f) - 8.4f;
            transform.position = new Vector3(r, 6, 0);
            OnFire();
            sum -= dis;
        }
    }

    public void OnFire()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
        //Debug.Log("발사");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Player"))
        {
            ani.SetBool("DIe", true);
            stop = true;
            Destroy(this.gameObject, 0.5f);
        }
    }

}
