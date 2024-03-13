using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading;
using UnityEngine.SceneManagement;

public class submitAssignment : MonoBehaviour
{
    private int correct = 0;
    private bool wrong = false;
    private GameObject correctPrompt;
    private GameObject wrongPrompt;
    private GameObject deadPrompt;
    private TMP_Text tries;
    private Image imageBlock;
    private Transform ansBlock;
    public bool assignStatement = false;
    private GameObject loadScene;

    private AssignSpeech speech;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        correctPrompt = GameObject.Find("CorrectPrompt");
        wrongPrompt = GameObject.Find("WrongPrompt");
        deadPrompt = GameObject.Find("DeadPrompt");
        loadScene = GameObject.Find("LoadScene");
        //correctPrompt.SetActive(false);
        if(correctPrompt != null)
        {
            correctPrompt.SetActive(false);
        }
        if(wrongPrompt != null)
        {
            wrongPrompt.SetActive(false);
        }
        if(deadPrompt != null)
        {
            deadPrompt.SetActive(false);
        }
        if(loadScene != null)
        {
            loadScene.SetActive(false);
        }
        //wrongPrompt.SetActive(false);
        //deadPrompt.SetActive(false);
        tries = GameObject.Find("Tries").GetComponent<TMP_Text>();

        ansBlock = transform.Find("AnsBlock");
        imageBlock = ansBlock.GetComponent<Image>();

        speech = FindObjectOfType<AssignSpeech>();
        if (speech != null)
        {
            speech.dialogue.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void finalize()
    {
        Transform ans = GameObject.Find("AnsVLG")?.transform;
        int health = int.Parse(tries.text);

        for(int i = 0; i < ans.childCount; i++)
        {
            TMP_Text ansText = ans.GetChild(i).GetChild(0).GetComponent<TMP_Text>();
            if(ansText != null )
            {
                string text = ansText.text;
                if(text.Contains("string weapon = \"sword\"") || text.Contains("string clothes = \"armor\""))
                {
                    correct++;
                }
                else
                {
                    wrong = true;
                    health = health - 1;
                    tries.text = health.ToString();
                    break;
                }
            }
        }

        if (wrong)
        {
            imageBlock.color = Color.red;
            wrongPrompt.SetActive(true);
        }

        if(health == 0)
        {
            imageBlock.color = Color.red;
            deadPrompt.SetActive(true);
        }


        if(correct == 2)
        {
            Debug.Log("Correct");
            imageBlock.color = Color.green;
            correctPrompt.SetActive(true);
            assignStatement = true;
            loadScene.SetActive(true);
        }
    }
    
    public void loadOverworld()
    {
        SceneManager.LoadScene("Platform");
    }
}
