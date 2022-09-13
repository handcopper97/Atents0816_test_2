using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float speed=5f;
    int score= 0;
    float currentScore = 0f;
   
    TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        Player p = FindObjectOfType<Player>();
        p.ScoreChange += SetScore;
        t = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        t.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(score > currentScore)
        {
            currentScore += Time.deltaTime * 10 * speed;
            currentScore = Mathf.Min(score, currentScore);
            t.text = $"{currentScore:f0}";
        }
    }

    void SetScore(int s)
    {
        score = s;
    }
}
