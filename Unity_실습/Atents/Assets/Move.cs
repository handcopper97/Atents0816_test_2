using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    Vector2 inputDir;
    public bool ing = false;
    public float speed=1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("시작");
    }
    //가나다
    // Update is called once per frame
    void Update()
    {
        if (ing)
        {
            transform.position += new Vector3(inputDir.x, inputDir.y, 0)*Time.deltaTime;
        }
        //Move_Key();
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
            transform.position += new Vector3(inputDir.x, inputDir.y, 0)*Time.deltaTime;
            ing = true;
            Debug.Log("버튼 눌림");

        }
        else if (context.canceled)
        {
            ing = false;
            Debug.Log("버튼 땜");
        }
        else
        {

        }
        
       
        Debug.Log(inputDir);

    }
    public void Shot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("발사");
        }
    }

    private static void Move_Key()
    {
        ////transform.position +=(speed * Time.deltaTime * Vector3.right);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("오른쪽 화살표가 눌렸습니다.");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("왼쪽 화살표가 눌렸습니다.");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("위쪽 화살표가 눌렸습니다.");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("아래쪽 화살표가 눌렸습니다.");
        }
    }
    /*
     * 실습0824    
     * 1. 인풋 시스템을 이용해서  wasd로 이동한다.
     *  1.1 키를 누르고 있으면 땔 때까지 해당 키 방향으로 계속 이동한다.
     * 2. 스페이스 키를 누르면 콘솔창에 "발사" 텍스트가 출력
     * 14:20 까지
     */
}
