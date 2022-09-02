using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class Player : MonoBehaviour
{

    public GameObject Bullet;
    public float speed=1f, speeded;
    Vector3 inputDir;
    //bool ing = false;
    Animator ani;
    PlayerInputAction inputActions;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    GameObject bullet;
    Vector3 bulletPosition;
    public int power = 0;
    void Awake()
    {
        //transform.DOMoveX(1, 5);
        //inputActions = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        inputActions = new PlayerInputAction();
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
        rigid.MovePosition(transform.position + speed * Time.fixedDeltaTime * inputDir);

        
        //transform.DOMoveX(100, 1);
    }
    /*
    // Update is called once per frame
    void OnEnable()
    {
        inputActions.Player.Enable();   // 오브젝트가 생성되면 입력을 받도록 활성화
        inputActions.Player.Move.performed += OnMove;   // performed 일 때 OnMove 함수 실행하도록 연결
        inputActions.Player.Move.canceled += OnMove;
    }
    void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMove;    // 연결해 놓은 함수 해제(안전을 위해)
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();  // 오브젝트가 사라질때 더 이상 입력을 받지 않도록 비활성화
    }
    */
    private void OnEnable()
    {
        inputActions.Player.Enable();   // 오브젝트가 생성되면 입력을 받도록 활성화
        inputActions.Player.Move.performed += OnMove;   // Move액션이 performed 일 때 OnMove 함수 실행하도록 연결
        inputActions.Player.Move.canceled += OnMove;    // Move액션이 canceled 일 때 OnMove 함수 실행하도록 연결
        inputActions.Player.Fire.performed += OnFire;
        inputActions.Player.Shift.performed += OnBoostOn;
        inputActions.Player.Shift.canceled += OnBoostOff;
    }

    /// <summary>
    /// 이 스크립트가 들어있는 게임 오브젝트가 비활성화 되었을 때 호출
    /// </summary>
    private void OnDisable()
    {
        inputActions.Player.Fire.performed -= OnFire;
        inputActions.Player.Move.canceled -= OnMove;    // 연결해 놓은 함수 해제(안전을 위해)
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();  // 오브젝트가 사라질때 더 이상 입력을 받지 않도록 비활성화
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
        if (power > 2)
        {
            power = 2;
        }else if (power < 0)
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




        Debug.Log("발사");
        if (context.started)
        {
            
        }

    }
    
    public void OnBoostOn(InputAction.CallbackContext context)
    {
        speeded = speed;
        speed *= 2;
    }
    public void OnBoostOff(InputAction.CallbackContext context)
    {
        speed = speeded;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Ast"))
        {
            Debug.Log("Game Over");
            Destroy(this.gameObject, 0.3f);
        }
        
    }
    /*
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
