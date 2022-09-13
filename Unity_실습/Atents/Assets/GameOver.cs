using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public float padeSpeed = 5;
    bool isDead = false;
    CanvasGroup cg;

    AudioSource ad;
    // Start is called before the first frame update
    void Start()
    {
        Player p = FindObjectOfType<Player>();
        p.PlayerDead += SetChildActive;

        ad = GameObject.Find("GameManager").GetComponent<AudioSource>();
        
        cg = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        //child 0 = image, 1 = text
        if (isDead)
        {
            ad.volume -= Time.deltaTime*0.1f;
            cg.alpha += Time.deltaTime;
        }
    }
    void SetChildActive()
    {
        StartCoroutine(Pade());
    }

    IEnumerator Pade()
    {
        
        yield return new WaitForSeconds(0.1f);
        
        isDead = true;
    }
}
