using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bossSpeech : MonoBehaviour
{
    public GameObject dialogue;
    private List<string> speech = new List<string>();
    int count = 0;

    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = GameObject.Find("BossDialogue");
        dialogue.SetActive(false);
        //speech.Add("I am the villager that gives if statement problems");
        speech.Add("I am the boss of this level!");
        speech.Add("I am here to test your knowledge on the coding concepts that you learned!");
        speech.Add("The challenge will contain everything that you have learned until now!");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogue.SetActive(true);
            text.text = speech[count];
            //count = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogue?.SetActive(false);
        count = 0;
    }
}
