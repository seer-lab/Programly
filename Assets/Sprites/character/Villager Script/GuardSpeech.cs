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
        //speech.Add("Hello there traveler!");
        speech.Add("Welcome to our village");
        speech.Add("Since you have entered our village, I assume you want to learn the basics of programming");
        speech.Add("To learn the basics of programming, there are multiple villagers settled across the village");
        speech.Add("that will give you challenges on certain concepts");
        speech.Add("To access those challenges just go near the villager and press the 'F' key");
        speech.Add("Upon completing the challenge a badge will be given");
        speech.Add("Once you have cleared all the challenges, there will be a big challenge to test your knowledge");
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
                }
                else
                {
                    dialogue.SetActive(false);
                }
                count++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.gameObject.tag == "Player")
        {
            dialogue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collide)
    {
        dialogue.SetActive(false);
    }
}
