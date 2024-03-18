using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading;
using UnityEngine.SceneManagement;

public class submitLoop : MonoBehaviour
{
    private GameObject correctPrompt;
    private GameObject wrongPrompt;
    private GameObject deadPrompt;
    private GameObject loadScene;

    private TMP_Text playerHealth;
    private TMP_Text bossHealth;
    private TMP_Text prompt;

    private Transform ansVLG;
    private int start = 0;
    private int end = 0;
    private int count = 0;

    private bool damaged = false;
    public bool forLoop = false;

    private Image imageBlock;
    private Transform ansBlock;

    public float posX;
    public float posY;
    public float posZ;
    public interactVillager temp;

    private ForSpeech speech;

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

        playerHealth = GameObject.Find("playerHealth").GetComponent<TMP_Text>();
        bossHealth = GameObject.Find("bossHealth").GetComponent<TMP_Text>();
        prompt = GameObject.Find("Prompt").GetComponent<TMP_Text>();
        ansVLG = transform.Find("AnsVLG");
        ansBlock = transform.Find("AnsBlock");
        imageBlock = ansBlock.GetComponent<Image>();


        /*GameObject[] scene = GameObject.FindGameObjectsWithTag("Platform");

        foreach (GameObject gameObj in scene)
        {
            gameObj.SetActive(false);
        }*/
        speech = FindObjectOfType<ForSpeech>();
        if(speech != null)
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
        int player = int.Parse(playerHealth.text);
        int boss = int.Parse(bossHealth.text);
        string answer = prompt.text;

        for(int i = 0; i < ansVLG.childCount; i++)
        {
            TMP_Text ansText = ansVLG.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
            count = 0;
            if(ansText != null)
            {
                string text = ansText.text;
                if (text.Contains("for") && i == 0)
                {
                    start = text[12];
                    end = text[19];
                    for(int x = start; x < end - 1; x++)
                    {
                        count++;
                    }
                    string final = count.ToString();
                    Debug.Log(final);
                    if (answer.Contains(final))
                    {
                        TMP_Text checkText = ansVLG.GetChild(1).GetChild(0).GetComponent<TMP_Text>();
                        if(checkText != null)
                        {
                            string check = checkText.text;
                            if (check.Contains("attack"))
                            {
                                boss = 0;
                            }
                            else
                            {
                                damaged = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        damaged = true;
                        break;
                    }
                }
                else if(i == 0 && !text.Contains("for"))
                {
                    damaged = true;
                    break;
                }
              //Debug.Log(text[12]);
                //19
            }
        }

        if(damaged)
        {
            player = player - 1;
            playerHealth.text = player.ToString();
            imageBlock.color = Color.red;
            wrongPrompt.SetActive(true);
        }

        if(player == 0)
        {
            imageBlock.color = Color.red;
            deadPrompt.SetActive(true);
            loadScene.SetActive(true);
        }

        if(boss == 0)
        {
            bossHealth.text = boss.ToString();
            correctPrompt.SetActive(true);
            loadScene.SetActive(true);
            forLoop = true;
            imageBlock.color = Color.green;
        }
    }

    public void loadOverworld()
    {
        SceneManager.LoadScene("Platform");

    }
}
