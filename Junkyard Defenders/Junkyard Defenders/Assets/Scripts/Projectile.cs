using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float projectileDamage = 10f;
    [SerializeField] bool projectilePenetration = false;
    [SerializeField] GameObject hitVFX;

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            GameObject hitVFXObject = Instantiate(hitVFX, transform.position, transform.rotation);
            Destroy(hitVFXObject, 2f);

            health.DealDamage(projectileDamage);

        if (projectilePenetration == false)
        {
            
            Destroy(gameObject);
        }
        else
        {
            projectilePenetration = false;
        }
        }
    }

}
