using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage;
    public flat effect_time = 2.5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, effect_time);
        Destroy(gameObject);

        collision.gameObject.GetComponent<Enemy_Behavior>().HP -= damage;
    }
}
