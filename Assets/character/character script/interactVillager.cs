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
            SceneManager.LoadScene("Game Mechanics");
        }
        else if(villagerName == "Assignment Villager")
        {
            SceneManager.LoadScene("Assign problem");
        }
        else if(villagerName == "For Villager")
        {
            SceneManager.LoadScene("For problem");
        }
    }

    private void loadBoss()
    {
        SceneManager.LoadScene("Boss Problem");
    }
}
