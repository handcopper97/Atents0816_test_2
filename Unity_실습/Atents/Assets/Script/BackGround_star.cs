using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BackGround_star : BackGround
{
    SpriteRenderer[] sp;
    void Start()
    {
        SetStart();
    }

    void Update()
    {
        ScrollingBack();
    }

    public override void SetStart()
    {
        base.SetStart();
        for (int i = 0; i < backgrounds.Length; i++)
        {
            //Debug.Log($"b.l은 {backgrounds.Length}개");
            sp =new SpriteRenderer[backgrounds[i].childCount];
            for (int h = 0; h < backgrounds[i].childCount; h++)
            {
                //Debug.Log($"b.child는 {backgrounds[i].childCount}개");
                //Debug.Log($"{backgrounds[i].GetChild(h).name}입니다.");
                sp[h] = backgrounds[i].GetChild(h).GetComponent<SpriteRenderer>();
                
                //backgrounds[i].GetChild(h).
                sp[h].flipX = switch_flip();
                sp[h].flipY = switch_flip();
                //Debug.Log("완료");
            }
            //sp[i] = backgrounds[i].GetChild(i).GetComponent<SpriteRenderer>();
        }

    }
    public override void ScrollingBack()
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
                //Debug.Log($"counter = {i}");
            }
        }
        if (counter > -1)
        {
            //배경 위치 리샛
            backgrounds[counter].position = new Vector2(x[counter] + LengthOfBack * 2 - LengthOfBack * counter, backgrounds[counter].position.y);
            //배경 축 플립하기
            sp = new SpriteRenderer[backgrounds[counter].childCount];
            for (int h = 0; h < backgrounds[counter].childCount; h++)
            {
                sp[h] = backgrounds[counter].GetChild(h).GetComponent<SpriteRenderer>();

                //backgrounds[i].GetChild(h).
                sp[h].flipX = switch_flip();
                sp[h].flipY = switch_flip();
            }
            //카운터 초기화
            counter = -1;
            counter_b = true;
        }
    }
    bool switch_flip()
    {
        bool flip = false;
        if (Random.value < 0.5f)
        {
            flip = true;
        }
        else
        {
            flip = false;
        }
        return flip;
    }
}
