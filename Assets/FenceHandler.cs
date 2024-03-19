using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceHandler : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] bool ifbadge = false;
    [SerializeField] bool forbadge = false;
    [SerializeField] bool assignbadge = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < player.transform.childCount; i++)
        {
            if(player.transform.GetChild(i).name == "If statement badge")
            {
                ifbadge = true;
            }
            else if(player.transform.GetChild(i).name == "Assignment badge")
            {
                assignbadge = true;
            }
            else if(player.transform.GetChild(i).name == "For loop badge")
            {
                forbadge = true;
            }
        }

        if(forbadge == true && ifbadge == true && assignbadge == true)
        {
            gameObject.SetActive(false);
        }
    }
}
