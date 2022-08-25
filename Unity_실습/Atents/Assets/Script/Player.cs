using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed=1f;
    UnityEngine.Vector2 inputDir;
    bool ing=false;
    PlayerInputAction inputActions;
    // Start is called before the first frame update
    void Start()
    {
        inputActions = new PlayerInputAction();
    }
    void Update()
    {
        if (ing)
        {
            transform.position += speed * Time.deltaTime * new Vector3(inputDir.x, inputDir.y, 0);
        }
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
    private void OnMove(InputAction.CallbackContext context)
    {
        // Exception : 예외 상황( 무엇을 해야 할지 지정이 안되어있는 예외 일때 )
        //throw new NotImplementedException();    // NotImplementedException 을 실행해라. => 코드 구현을 알려주기 위해 강제로 죽이는 코드

        Debug.Log("이동 입력");
    }
    public void Fire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("발사");
        }
        
    }
    public void MoveInput(InputAction.CallbackContext context)
    {
        

        inputDir = context.ReadValue<Vector2>();
        if (context.started)
        {
            Debug.Log("입력값 인식");
        }
        else if (context.performed)
        {
            transform.position += new Vector3(inputDir.x, inputDir.y, 0) * Time.deltaTime;
            ing = true;
            //Debug.Log("버튼 눌림");

        }
        else if (context.canceled)
        {
            ing = false;
            //Debug.Log("버튼 땜");
        }
        else
        {

        }


        Debug.Log(inputDir);

    }
}
