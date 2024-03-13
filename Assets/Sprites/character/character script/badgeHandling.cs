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
    public submitLoop loop;
    private PlatformDontDestroy check;

    // Start is called before the first frame update
    void Start()
    {
        ans = FindObjectOfType<submitAnswer>();
        /*badges = GameObject.Find("NonCollected")?.transform;
        player = transform.Find("Player");*/

        assign = FindObjectOfType<submitAssignment>();
        loop = FindObjectOfType<submitLoop>();
        check = FindObjectOfType<PlatformDontDestroy>();

        GameObject[] scene = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");

        foreach(GameObject gameObj in scene)
        {
            gameObj.SetActive(false);
        }


        if(loop != null)
        {


            GameObject[] platformscene = GameObject.FindGameObjectsWithTag("Platform");
            int length = platformscene.Length / 2;
            /*foreach(GameObject gameObj in platformscene)
            {
                gameObj?.SetActive(false);
            }*/
            for (int i = length; i < platformscene.Length; i++)
            {
                //platformscene[i].SetActive(false);
                Destroy(platformscene[i]);
            }


            //Vector3 newPosition = new Vector3(loop.posX, loop.posY, loop.posZ);
            /*gameObject.transform.position.x = loop.posX;
            gameObject.transform.position.y = loop.posY;
            gameObject.transform.position.z = loop.posZ;*/
            //gameObject.transform.position = newPosition;

            badges = GameObject.Find("NonCollected")?.transform;
            if(check != null)
            {
                player = check.player.transform;
            }

            if (loop.forLoop == true)
            {
                for (int i = 0; i < badges.childCount; i++)
                {
                    if (badges.GetChild(i).gameObject.name == "For loop badge")
                    {
                        badges.GetChild(i).SetParent(player, false);
                    }
                }
            }
        }

        else if(ans != null)
        {
            GameObject[] platformscene = GameObject.FindGameObjectsWithTag("Platform");
            int length = platformscene.Length / 2;
            /*foreach(GameObject gameObj in platformscene)
            {
                gameObj?.SetActive(false);
            }*/
            for (int i = length; i < platformscene.Length; i++)
            {
                //platformscene[i].SetActive(false);
                Destroy(platformscene[i]);
            }


            //Vector3 newPosition = new Vector3(loop.posX, loop.posY, loop.posZ);
            /*gameObject.transform.position.x = loop.posX;
            gameObject.transform.position.y = loop.posY;
            gameObject.transform.position.z = loop.posZ;*/
            //gameObject.transform.position = newPosition;

            badges = GameObject.Find("NonCollected")?.transform;
            if (check != null)
            {
                player = check.player.transform;
            }

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

        else if(assign != null)
        {
            GameObject[] platformscene = GameObject.FindGameObjectsWithTag("Platform");
            int length = platformscene.Length / 2;
            /*foreach(GameObject gameObj in platformscene)
            {
                gameObj?.SetActive(false);
            }*/
            /*for(int i = 0; i < length; i++)
            {
                platformscene[i].SetActive(true);
            }*/

            for (int i = length; i < platformscene.Length; i++)
            {
                //platformscene[i].SetActive(false);
                Destroy(platformscene[i]);
            }



            //Vector3 newPosition = new Vector3(loop.posX, loop.posY, loop.posZ);
            /*gameObject.transform.position.x = loop.posX;
            gameObject.transform.position.y = loop.posY;
            gameObject.transform.position.z = loop.posZ;*/
            //gameObject.transform.position = newPosition;

            badges = GameObject.Find("NonCollected")?.transform;
            if (check != null)
            {
                player = check.player.transform;
            }

            if (assign.assignStatement == true)
            {
                for (int i = 0; i < badges.childCount; i++)
                {
                    if (badges.GetChild(i).gameObject.name == "Assignment badge")
                    {
                        badges.GetChild(i).SetParent(player, false);
                    }
                }
            }
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
        /*if(loop != null)
        {
            Debug.Log("Checking");
            if(loop.forLoop == true)
            {
                for(int i = 0; i < badges.childCount; i++)
                {
                    if(badges.GetChild(i).gameObject.name == "For loop badge")
                    {
                        badges.GetChild(i).SetParent(player, false);
                    }
                }
            }
        }*/
    }
}
