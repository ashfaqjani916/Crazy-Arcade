using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public HealthBar healthBar;
    public int currentHealth;

    public int MaxHealth = 10;

    private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(currentHealth);
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log(currentHealth);
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
        }
        
    }
}
