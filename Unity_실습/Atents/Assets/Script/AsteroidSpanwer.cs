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

            r = Random.Range(0, 9) - 4.5f;
            GameObject a = Instantiate(Ast, new Vector3(transform.position.x, r), transform.rotation);


            if (r <= 0)
            {
                min =1;
            }
            else
            {
                min = -1;
            }
            r = Random.Range(0, 4.5f)*min;
            a.GetComponent<Ast>().dis = new Vector3(-11, r);

            counter++;
            if (counter > NumOfSpanwer)
            {
                break;
            }

        }

    }
}
