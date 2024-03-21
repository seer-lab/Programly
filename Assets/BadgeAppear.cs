using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeAppear : MonoBehaviour
{
    [SerializeField] GameObject assignbadge;
    [SerializeField] GameObject forbadge;
    [SerializeField] GameObject ifbadge;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        assignbadge.SetActive(false);
        forbadge.SetActive(false);
        ifbadge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < player.transform.childCount; i++)
        {
            if(player.transform.GetChild(i).gameObject.name == "If statement badge")
            {
                ifbadge.SetActive(true);
            }
            else if(player.transform.GetChild(i).gameObject.name == "Assignment badge")
            {
                assignbadge.SetActive(true);
            }
            else if(player.transform.GetChild(i).gameObject.name == "For loop badge")
            {
                forbadge.SetActive(true);
            }
        }
    }
}
