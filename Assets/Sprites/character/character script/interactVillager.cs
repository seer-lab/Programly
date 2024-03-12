using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interactVillager : MonoBehaviour
{
    bool collided = false;
    private string villagerName;
    
    // Update is called once per frame
    void Update()
    {
        if(collided == true)
        {
            if(Input.GetKeyDown(KeyCode.F)){
                loadChallenge();
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
    }
}
