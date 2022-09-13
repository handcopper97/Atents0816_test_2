using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using Random = UnityEngine.Random;
//using Unity.Mathematics;

public class Player : MonoBehaviour
{
    //변수
    public GameObject Bullet;
    public float speed = 1f, speeded, timeToDie = 3f, timeToGod = 3f;
    Vector3 inputDir;
    public bool isDead = false, god = false;

    Animator ani;
    PlayerInputAction inputActions;
    Rigidbody2D rigid;
    SpriteRenderer sp;
    // Start is called before the first frame update
    GameObject bullet;
    AudioSource audio;
    Vector3 bulletPosition;
    public int power = 0, HP = 10, totalscore=0;
    public Action<int> HealthChange;
    public Action<int> ScoreChange;
    public Action PlayerDead;

    void Awake()
    {
        //transform.DOMoveX(1, 5);
        //inputActions = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        inputActions = new PlayerInputAction();
        audio = GetComponent<AudioSource>();

        AddScore(0);//스코어 초기화 용
    }
    private void Start()
    {
        HealthChange(HP);
    }
    void FixedUpdate()
    {
        //피하기 게임 용 무브
        /*
        if (inputDir.y != 0)
        {
            inputDir.y = 0;
            rigid.MovePosition(transform.position + speed * Time.fixedDeltaTime * inputDir);
        }
        else
        {
            rigid.MovePosition(transform.position + speed * Time.fixedDeltaTime * inputDir);
        }
        */
        
        //transform.DOMoveX(100, 1);
        if (isDead)
        {
            rigid.AddForce(Vector2.left * 0.1f, ForceMode2D.Impulse);   // 죽었을 때 뒤로 돌면서 튕겨나가기
            rigid.AddTorque(10.0f);
        }
        else
        {
            rigid.MovePosition(transform.position + speed * Time.fixedDeltaTime * inputDir);
        }
    }
    private void OnEnable()
    {
        inputActions.Player.Enable();   // 오브젝트가 생성되면 입력을 받도록 활성화
       
        inputActions.Player.Shift.canceled += OnBoostOff;
        inputActions.Player.Shift.performed += OnBoostOn;
        //inputActions.Player.Fire.canceled += OnFire;
        inputActions.Player.Fire.performed += OnFire;
        inputActions.Player.Move.canceled += OnMove;    // 연결해 놓은 함수 해제(안전을 위해)
        inputActions.Player.Move.performed += OnMove;
    }
    /// <summary>
    /// 이 스크립트가 들어있는 게임 오브젝트가 비활성화 되었을 때 호출
    /// </summary>
    private void OnDisable()
    {

        InputDisable();
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        // Exception : 예외 상황( 무엇을 해야 할지 지정이 안되어있는 예외 일때 )
        //throw new NotImplementedException();    // NotImplementedException 을 실행해라. => 코드 구현을 알려주기 위해 강제로 죽이는 코드

        inputDir = context.ReadValue<Vector2>();    // 어느 방향으로 움직여야 하는지를 입력받음

        ani.SetFloat("InputY", inputDir.y);
        //dir.y > 0   // W를 눌렀다.
        //dir.y == 0  // W,S 중 아무것도 안눌렀다.
        //dir.y < 0   // S를 눌렀다.

    }
    public void OnFire(InputAction.CallbackContext context)
    {
        audio.Play();

        if (power > 2)
        {
            power = 2;
        }
        else if (power < 0)
        {
            power = 0;
        }

        switch (power)
        {
            case 0:
                bulletPosition = new Vector3(transform.position.x + 1f, transform.position.y);
                bullet = Instantiate(Bullet, bulletPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                bullet.GetComponent<Bullet>().inputDir = new Vector3(1, 0);
                break;

            case 1:
                bulletPosition = new Vector3(transform.position.x + 1f, transform.position.y + 1f);
                bullet = Instantiate(Bullet, bulletPosition, Quaternion.Euler(new Vector3(0, 0, 45)));
                bullet.GetComponent<Bullet>().inputDir = new Vector3(1, 1);
                bulletPosition = new Vector3(transform.position.x + 1f, transform.position.y - 1f);
                bullet = Instantiate(Bullet, bulletPosition, Quaternion.Euler(new Vector3(0, 0, -45)));
                bullet.GetComponent<Bullet>().inputDir = new Vector3(1, -1);
                break;

            case 2:
                bulletPosition = new Vector3(transform.position.x + 1f, transform.position.y);
                bullet = Instantiate(Bullet, bulletPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                bullet.GetComponent<Bullet>().inputDir = new Vector3(1, 0);

                bulletPosition = new Vector3(transform.position.x + 1f, transform.position.y + 1f);
                bullet = Instantiate(Bullet, bulletPosition, Quaternion.Euler(new Vector3(0, 0, 45)));
                bullet.GetComponent<Bullet>().inputDir = new Vector3(1, 1);

                bulletPosition = new Vector3(transform.position.x + 1f, transform.position.y - 1f);
                bullet = Instantiate(Bullet, bulletPosition, Quaternion.Euler(new Vector3(0, 0, -45)));
                bullet.GetComponent<Bullet>().inputDir = new Vector3(1, -1);
                break;

            default:
                break;
        }

        /*
        bulletPosition = new Vector3(transform.position.x+1f, transform.position.y+1f);
        bullet = Instantiate(Bullet, bulletPosition, Quaternion.Euler(new Vector3(0, 0, 45)));
        bullet.GetComponent<Bullet>().inputDir = new Vector3(1, 1);
        bulletPosition = new Vector3(transform.position.x + 1f, transform.position.y);
        bullet = Instantiate(Bullet, bulletPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
        bullet.GetComponent<Bullet>().inputDir = new Vector3(1, 0);
        bulletPosition = new Vector3(transform.position.x + 1f, transform.position.y-1f);
        bullet = Instantiate(Bullet, bulletPosition, Quaternion.Euler(new Vector3(0, 0, -45)));
        bullet.GetComponent<Bullet>().inputDir = new Vector3(1, -1);
        */

    }

    public void OnBoostOn(InputAction.CallbackContext context)
    {
        speeded = speed;
        speed *= 2;
    }
    public void OnBoostOff(InputAction.CallbackContext context)
    {
        speed = speeded;
    }//On, Dis 함수들(활성화되어있는 상태. 지우면 안댐)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ast")) && !god)
        {
            Attacked();
        }
        if (god)
        {

        }
    }
    void Attacked()
    {
        HP--;
        HealthChange(HP);
        Debug.Log($"HP감소. 현재 HP = {HP}입니다.");
        if (HP <= 0 && !isDead)
        {
            god = true;
            Debug.Log("die");
            StartCoroutine(GameOver());
        }
        else
        {
            StartCoroutine(GodMoad());
        }
    }
    public void AddScore(int s)
    {
        totalscore += s;
        ScoreChange?.Invoke(totalscore);
    }
    IEnumerator GameOver()
    {
        
        isDead = true;
        GetComponent<Collider2D>().enabled = false;
        InputDisable();
        rigid.gravityScale = 1.0f;
        rigid.freezeRotation = false;
        yield return new WaitForSeconds(timeToDie);
        PlayerDead();
        Destroy(gameObject);
        //Time.timeScale = 0;
    }
    IEnumerator GodMoad()
    {
        god = true;
        //Debug.Log("무적 시작");
        for (double i = 0; i < timeToGod; i += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            Color c = sp.color;
            c.a = Random.value;
            
            sp.color = c;
        }
        sp.color = Color.white;
        //Debug.Log("무적 끝");
        //yield return new WaitForSeconds(timeToGod);
        god = false;
    }
    void InputDisable()
    {
        inputActions.Player.Shift.canceled -= OnBoostOff;
        inputActions.Player.Shift.performed -= OnBoostOn;
        //inputActions.Player.Fire.canceled -= OnFire;
        inputActions.Player.Fire.performed -= OnFire;
        inputActions.Player.Move.canceled -= OnMove;    // 연결해 놓은 함수 해제(안전을 위해)
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();  // 오브젝트가 사라질때 더 이상 입력을 받지 않도록 비활성화
    }
    
    /*무브 인풋 시스템(전)
    public void MoveInput(InputAction.CallbackContext context)
    {
        ani.SetFloat("InputY", inputDir.y);


        inputDir = context.ReadValue<Vector2>();
        
        if (context.started)
        {
            
            
            
            
            Debug.Log("입력값 인식");
        }
        if (context.performed)
        {
            transform.position += new Vector3(inputDir.x, inputDir.y, 0) * Time.deltaTime;
            ing = true;
            //Debug.Log("버튼 눌림");

        }
        if (context.canceled)
        {
           // ani.SetFloat("InputY", inputDir.y);

            ing = false;

            

            //Debug.Log("버튼 땜");
        }



        Debug.Log(inputDir);

    }
    */
}
