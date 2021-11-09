using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistingObjects : MonoBehaviour
{
    int sceneIndex;
    private void Awake()
    {
        int persistingObjectNumber = FindObjectsOfType<PersistingObjects>().Length;
        if (persistingObjectNumber > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != sceneIndex)
        {
            Destroy(gameObject);
        }
    }
}
