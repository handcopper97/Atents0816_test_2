using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();  
        Destroy(this.gameObject, ani.GetCurrentAnimatorClipInfo(0)[0].clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
