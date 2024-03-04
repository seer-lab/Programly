using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class badgeHandling : MonoBehaviour
{
    //public submitAnswer ans;
    public submitAnswer ans;
    private Transform badges;
    private Transform player;
    public submitAssignment assign;

    // Start is called before the first frame update
    void Start()
    {
        ans = FindObjectOfType<submitAnswer>();
        badges = GameObject.Find("NonCollected")?.transform;
        player = transform.Find("Player");

        assign = FindObjectOfType<submitAssignment>();

        GameObject[] scene = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");

        foreach(GameObject gameObj in scene)
        {
            gameObj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ans != null)
        {
            if (ans.ifStatement == true)
            {
                for (int i = 0; i < badges.childCount; i++)
                {
                    if (badges.GetChild(i).gameObject.name == "If statement badge")
                    {
                        badges.GetChild(i).SetParent(player, false);
                    }
                }
            }
        }
        if(assign != null)
        {
            if(assign.assignStatement == true)
            {
                for(int i = 0; i < badges.childCount; i++)
                {
                    if(badges.GetChild(i).gameObject.name == "Assignment badge")
                    {
                        badges.GetChild(i).SetParent(player, false);
                    }
                }
            }
        }
    }
}
