using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class AsteroidSpanwer : MonoBehaviour
{
    public float Spawn_time = 1f;
    public int NumOfSpanwer = 10;
    float r, min;
    int counter = 0;
    public GameObject Ast;
    Vector3 dis;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(AsteroidSpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator AsteroidSpawn()
    {

        while (true)
        {
            yield return new WaitForSeconds(Spawn_time);

            r = Random.Range(-4.5f, 4.5f);
            GameObject a = Instantiate(Ast, new Vector3(transform.position.x, r), transform.rotation);
            

            r = Random.Range(-4.5f, 4.5f);
            a.GetComponent<Ast>().dis = new Vector3(-1-Mathf.Abs(r), r);

            counter++;
            if (counter > NumOfSpanwer)
            {
                break;
            }

        }

    }
}
