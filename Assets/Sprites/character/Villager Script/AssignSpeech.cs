using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AssignSpeech : MonoBehaviour
{
    public GameObject dialogue;
    private List<string> speech = new List<string>();
    int count = 0;

    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = GameObject.Find("AssignDialogue");
        dialogue.SetActive(false);
        speech.Add("Assign statement is a concept that basically lets you attach an action to variable");
        speech.Add("To identify a assignment statement the '=' sign should be present and before it should consist the variable name");
        speech.Add("And the statement after the '=' is the statement you are assigning to the variable name");
        speech.Add("Another important thing to note that before the variable name there should be a type attached to them");
        speech.Add("Basic types would include 'string' for words, 'int' for numbers and char for 'letters'");
        speech.Add("An example of an assignment statement would be 'string talk = \"hello\"");
        speech.Add("This example shows that the variable name 'talk' has a type of string and has the word 'hello' attached/assigned to it");
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
