using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashToStart : MonoBehaviour
{
    [SerializeField] float splashWaitTime = 4f;

    void Start()
    {
        FindObjectOfType<LevelLoader>().SplashToStartMenu(splashWaitTime);
    }


}
