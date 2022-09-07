using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    TextMeshProUGUI t;

    private void Awake()
    {
        t = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        Player p = FindObjectOfType<Player>();
        p.HealthChange += RefreshHealth;
    }
    void RefreshHealth(int life)
    {
        t.text = "X "+life.ToString();
    }

}
