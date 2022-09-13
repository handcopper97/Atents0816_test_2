using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource ad = GetComponent<AudioSource>();
        ad.Play();
        if (!ad.loop)
        {
            ad.loop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
