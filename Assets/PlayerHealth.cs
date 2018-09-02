using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int healthDecrease;
    [SerializeField] Text healthText;


    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        health = health - healthDecrease;
        healthText.text = health.ToString();
        
    }
}
