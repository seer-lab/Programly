using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuardSpeech : MonoBehaviour
{
    private GameObject dialogue;
    private List<string> speech = new List<string>();
    int count = 0;

    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = GameObject.Find("GuardDialogue");
        dialogue.SetActive(false);
        speech.Add("Hello there traveler!");
        speech.Add("Welcome to our village");
        speech.Add("Since you have entered our village, I assume you want to learn the basics of programming");
        speech.Add("To learn the basics of programming, there are multiple villagers settled across the village");
        speech.Add("that will give you challenges on certain concepts");
        speech.Add("To access those challenges just go near the villager and press the 'F' key");
        speech.Add("Upon completing the challenge a badge will be given");
        speech.Add("Once you have cleared all the challenges, the gate at the end of the path will open up");
        speech.Add("Once the gate opens up, the path will directly lead you to the boss where your knowledge will then be tested");
        speech.Add("Good luck traveler!");
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue != null)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(count < speech.Count)
                {
                    text.text = speech[count];
                    count++;
                }
                else
                {
                    dialogue.SetActive(false);
                    count = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.gameObject.tag == "Player")
        {
            dialogue.SetActive(true);
            text.text = speech[0];
            count = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            dialogue.SetActive(false);
            count = 1;
            text.text = speech[0];
        }
    }
}
