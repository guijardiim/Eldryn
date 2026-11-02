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

using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1;

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
}