using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void TakeDamage()
    {
        Destroy(gameObject); // ”ничтожаем врага
    }
}