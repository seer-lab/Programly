using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IfSpeech : MonoBehaviour
{
    public GameObject dialogue;
    private List<string> speech = new List<string>();
    int count = 0;

    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = GameObject.Find("IfDialogue");
        dialogue.SetActive(false);
        speech.Add("If Else statements are concepts that teach you if a certain condition is fulfilled it will do the following thing");
        speech.Add("And if the condition isn't fulfilled it would follow the one under the else statement");
        speech.Add("There are other things to learn about it such as 'else if' but those two would be enough to start off");
        speech.Add("Good luck on your challenge, traveler!");
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(count < speech.Count) 
                {
                    text.text = speech[count];
                }
                else
                {
                    dialogue.SetActive(false);
                }
                count++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dialogue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogue?.SetActive(false);
    }
}
