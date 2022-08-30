using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    public float enemy_time = 2f;
    public GameObject enemy;
    float r;
    int counter=0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawn()
    {

        while (true)
        {
            yield return new WaitForSeconds(enemy_time);

            r = Random.Range(0, 9) - 4.5f;
            Instantiate(enemy, new Vector3(transform.position.x, r, transform.position.z), transform.rotation);
            counter++;
            if(counter > 10)
            {
                break;
            }

        }

    }
}
