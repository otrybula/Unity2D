using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        FindObjectOfType<HealthDisplay>().RemoveLives();
        Destroy(otherCollider.gameObject);
    }
}
