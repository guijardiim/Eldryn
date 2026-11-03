/*using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1;
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
    }
}
*/

using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1;
    public Transform attackPoint;
    public float weaponRange;
    public LayerMask playerLayer;


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Tenta pegar o componente PlayerHealth do objeto que encostou no inimigo
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        // Só aplica o dano se o objeto realmente tiver o script PlayerHealth (ou seja, se for o player)
        if (playerHealth != null)
        {
            playerHealth.ChangeHealth(-damage);
        }
    }

    public void Attack()    
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
        }
    }
}