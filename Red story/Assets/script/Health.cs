using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth { get; private set; }
    private Animator animation;
    // Start is called before the first frame update
    private bool dead = false;
    void Start()
    {
        currentHealth = startingHealth;
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0 , startingHealth);
        if(currentHealth > 0)
        {
            animation.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                animation.SetTrigger("dead");

                GetComponent<PlayerController>().enabled = false;
                dead = true;
            }
           
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

}
