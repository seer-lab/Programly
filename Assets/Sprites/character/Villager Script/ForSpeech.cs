using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForSpeech : MonoBehaviour
{
    public GameObject dialogue;
    private List<string> speech = new List<string>();
    int count = 0;

    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = GameObject.Find("ForDialogue");
        dialogue.SetActive(false);
        //speech.Add("I am the villager that teaches for loops!");
        speech.Add("For loops are concepts that allow you to repeat an action to a certain number of times");
        speech.Add("To identify a for loop the 'for' word should be found followed by a '()' with the conditions of the for loop being inside the '()'");
        speech.Add("An example to this would be 'for(int i = 0; i < 3; i++)'");
        speech.Add("This specific example shows that the loop will run 3 times the reason for this is because it starts off as 0 from the 'int i = 0'");
        speech.Add("Then the condition it will keep going until it reaches the condition is 'i < 3' in which case as long as 'i' is less than 3 it will keep running");
        speech.Add("The final part of 'i++' is after every run 'i' will be increased by 1 so that the loop won't keep on running forever");
        speech.Add("In short you can think of the conditions inside of '()' as 'starting point', 'condition until it stops running' and 'action needs to be done before it is ran again' each separated by ';'");
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (count < speech.Count)
                {
                    text.text = speech[count];
                }
                else
                {
                    dialogue.SetActive(false);
                    count = 0;
                }
                count++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogue?.SetActive(false);
    }
}
