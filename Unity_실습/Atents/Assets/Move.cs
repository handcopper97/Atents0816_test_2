using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //°¡³ª´Ù
    // Update is called once per frame
    void Update()
    {
        transform.position +=(speed * Time.deltaTime * Vector3.right);
    }
}
