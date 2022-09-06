using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_star : BackGround
{
    SpriteRenderer[] sp;
    // Start is called before the first frame update
    void Start()
    {
        SetStart();
    }

    // Update is called once per frame
    void Update()
    {
        ScrollingBack();
    }

    public override void SetStart()
    {
        base.SetStart();
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Debug.Log($"b.l은 {backgrounds.Length}개");
            sp =new SpriteRenderer[backgrounds[i].childCount];
            for (int h = 0; h < backgrounds[i].childCount; h++)
            {
                Debug.Log($"b.child는 {backgrounds[i].childCount}개");
                Debug.Log($"{backgrounds[i].GetChild(h).name}입니다.");
                sp[h] = backgrounds[i].GetChild(h).GetComponent<SpriteRenderer>();
                
                //backgrounds[i].GetChild(h).
                sp[h].flipX = switch_flip();
                sp[h].flipY = switch_flip();
                Debug.Log("완료");
            }
            //sp[i] = backgrounds[i].GetChild(i).GetComponent<SpriteRenderer>();
        }

    }
    public override void ScrollingBack()
    {
        base.ScrollingBack();
        


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
