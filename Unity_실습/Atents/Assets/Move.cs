using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
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
        //Move_Key();
    }
    public void MoveInput(InputAction.CallbackContext context)
    {
        Debug.Log("입력들어옴");
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
}
