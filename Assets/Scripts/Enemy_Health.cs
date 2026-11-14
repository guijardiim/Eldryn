using UnityEngine;
using UnityEngine.Assemblies;
using UnityEngine.Rendering;

public class Enemy_Health : MonoBehaviour
{

    public int currenHealth;
    public int maxHealth;

    public void Start()
    {
        currenHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currenHealth += amount;

        if(currenHealth > maxHealth)
        {
            currenHealth = maxHealth;
        }
        else if (currenHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
