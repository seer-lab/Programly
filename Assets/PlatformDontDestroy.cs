using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDontDestroy : MonoBehaviour
{
    public GameObject player;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        player = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
