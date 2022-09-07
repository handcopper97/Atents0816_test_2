using System.Net;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class BackGround : MonoBehaviour
{
    public float speed;
    public Transform[] backgrounds;
    public const float LengthOfBack = 13.6f;

    public int counter = -1;
    public bool counter_b = true;
    public float[] x;

    //float leftPosX = 0f;
    //float rightPosX = 0f;
    //float xScreenHalfSize;
    //float yScreenHalfSize;
    // Start is called before the first frame update
    void Start()
    {
        SetStart();

        //카메라 절대값으로 스크롤링 코드
        //yScreenHalfSize = Camera.main.orthographicSize;
        //xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        //leftPosX = -(xScreenHalfSize * 2);
        //rightPosX = xScreenHalfSize * 2 * backgrounds.Length;


        //Debug.Log($"백그라운드 길이는 {backgrounds.Length}입니다")
    }
    public virtual void SetStart()
    {
        x = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            x[i] = backgrounds[i].position.x;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ScrollingBack();

        //카메라 절대값으로 스크롤링 코드
        //Vector3 dis = new Vector3(-1, 0);
        //transform.Translate(speed * Time.deltaTime * dis, Space.World);


        //for (int i = 0; i < backgrounds.Length; i++)
        //{
        //    backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;

        //    if (backgrounds[i].position.x < leftPosX)
        //    {
        //        Vector3 nextPos = backgrounds[i].position;
        //        nextPos = new Vector3(nextPos.x + rightPosX, nextPos.y, nextPos.z);
        //        backgrounds[i].position = nextPos;
        //    }
        //}
    }

    public virtual void ScrollingBack()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector2 dis = new Vector2(-1, 0);
            backgrounds[i].Translate((speed * Time.deltaTime * dis), Space.World);
            //원래 벡터값x가 현재 벡터x+스프라이트 가로값+스프라이트 가로값 * 배열인덱스(배열 순서가 뒤로 밀릴 수록 원래 벡터x가 큼)보다 크면 실행
            if (x[i] > backgrounds[i].position.x + LengthOfBack + LengthOfBack * i && counter_b)
            {
                counter_b = false;
                counter = i;
            }

        }
        if (counter > -1)
        {
            backgrounds[counter].position = new Vector2(x[counter] + LengthOfBack * 2 - LengthOfBack * counter, backgrounds[counter].position.y);
            counter = -1;
            counter_b = true;
        }
    }

    
}
