using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;
    [SerializeField] GameObject hitVFX;
    [SerializeField] float hitDuration = 0.5f;
    // Start is called before the first frame update

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
        GameObject hitEffect = Instantiate(hitVFX, transform.position, transform.rotation);
        Destroy(hitEffect, hitDuration);
    }
}
