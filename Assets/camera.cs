using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        GameObject[] camera = GameObject.FindGameObjectsWithTag("Camera");
        if(camera.Length > 1)
        {
            Destroy(camera[1]);
        }
    }
}
