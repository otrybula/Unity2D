using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScroll : MonoBehaviour
{
    [SerializeField] float tileScrollSpeed = 0.1f;
    [SerializeField] float maxHeight = 2f;
    [SerializeField] float minHeight = 0f;
    [SerializeField] bool onMaxOrMin = false;
    int waterControl = 1;
    // Start is called before the first frame update
    void Start()
    {
      minHeight = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxHeight)
        {
            waterControl = -1;
        }
        if (transform.position.y < minHeight)
        {
            waterControl= 1;
        }
        transform.Translate(new Vector2(0f, tileScrollSpeed * waterControl * Time.deltaTime));
    }
}
