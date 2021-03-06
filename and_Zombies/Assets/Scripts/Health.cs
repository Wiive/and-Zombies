using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Value's")]
    [SerializeField] protected int maxHealth = 3;
    [SerializeField] protected int currentHealth;
    [Header("UI")]
    [SerializeField] private GameObject[] UI_Heart;
    [SerializeField] private GameObject LoseScreen;

    public virtual void Start()
    {
        currentHealth = maxHealth;
        
    }

    void Update()
    {

    }
    public virtual void DamagePlayer(int damage)
    {

        currentHealth -= damage;
        UI_Heart[currentHealth].SetActive(false);
        Checkhealth();
    }
    public virtual void ChangeHealth(int amount)
    {
        currentHealth = currentHealth + amount;
        UI_Heart[currentHealth - 1].SetActive(true);
        Checkhealth();
    }

    protected virtual void Checkhealth()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Kill();
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public virtual void Kill()
    {
        LoseScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
