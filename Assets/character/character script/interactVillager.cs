using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interactVillager : MonoBehaviour
{
    bool collided = false;
    private string villagerName;
    List<GameObject> badges = new List<GameObject>();
    private bool isBoss = false;
    public bool badgeTempGone = false;
    
    // Update is called once per frame
    void Update()
    {
        if(collided == true)
        {
            if(Input.GetKeyDown(KeyCode.F)){
                //loadChallenge();
                if(isBoss == true)
                {
                    loadBoss();
                }
                else
                {
                    loadChallenge();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Villager")
        {
            collided = true;
            villagerName = collision.gameObject.name;
            Debug.Log("Collided");
        }
        else if(collision.gameObject.tag == "Boss")
        {
            collided = true;
            isBoss = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
    }

    private void loadChallenge()
    {
        if(villagerName == "If Villager")
        {
            badgeTempGone = true;
            SceneManager.LoadScene("Game Mechanics");
        }
        else if(villagerName == "Assignment Villager")
        {
            badgeTempGone = true;
            SceneManager.LoadScene("Assign problem");
        }
        else if(villagerName == "For Villager")
        {
            badgeTempGone = true;
            SceneManager.LoadScene("For problem");
        }
    }

    private void loadBoss()
    {
        badgeTempGone = true;
        SceneManager.LoadScene("Boss Problem");
    }
}
