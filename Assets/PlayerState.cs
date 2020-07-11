using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public Rigidbody2D rb;
    public float MaxHealth = 100;
    public float MaxSpeed = 0;
    [SerializeField] private float currentHealth;
    [SerializeField] private bool DEAD;
    // Start is called before the first frame update
    void Start()
    {
        if (rb.Equals(null))
        {
            rb = GetComponent<Rigidbody2D>();
        }
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            DEAD = true;
        }
    }

    public float takeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            DEAD = true;
        }
        return currentHealth;
        
    }

    public bool isDead()
    {
        return DEAD;
    }

    public float getSpeed()
    {
        return rb.velocity.magnitude;
    }


    public float getHealth()
    {
        return currentHealth;
    }
}
