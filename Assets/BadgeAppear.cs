using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeAppear : MonoBehaviour
{
    [SerializeField] GameObject assignbadge;
    [SerializeField] GameObject forbadge;
    [SerializeField] GameObject ifbadge;
    [SerializeField] GameObject player;
    [SerializeField] interactVillager temp;

    [SerializeField] private GameObject iftemp;
    [SerializeField] private GameObject fortemp;
    [SerializeField] private GameObject assigntemp;
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

        if(temp.badgeTempGone == true)
        {
            for(int i = 0; i < player.transform.childCount; i++)
            {
                player.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if(temp.badgeTempGone == false)
        {
            for (int i = 0; i < player.transform.childCount; i++)
            {
                player.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        if(iftemp.activeSelf == false)
        {
            ifbadge.SetActive(false);
        }
        if(fortemp.activeSelf == false)
        {
            forbadge.SetActive(false);
        }
        if(assigntemp.activeSelf == false)
        {
            assignbadge.SetActive(false);
        }
    }
}
