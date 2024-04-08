using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading;
using UnityEngine.SceneManagement;

public class submitAnswer : MonoBehaviour
{
    private bool checking = false;
    private TMP_Text prompt;
    public int correct = 0;
    private bool answered = false;
    private TMP_Text bossHealth;
    private TMP_Text playerHealth;
    private bool Damaged = false;

    private GameObject correctAns;
    private GameObject wrongAns;

    private bool isStunChecker = false;
    private bool notStunnedChecker = false;

    private Transform ansBlock;
    private Image imageBlock;
    private GameObject tryAgain;
    private Transform submitButton;
    private Transform loadButton;

    private IfSpeech speech;

    public bool ifStatement = false;
    private GameObject player;
    private interactVillager temp;
    // Start is called before the first frame update

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        player = GameObject.Find("Player");
        temp = player.GetComponent<interactVillager>();
    }

    void Start()
    {
        prompt = GameObject.Find("Prompt").GetComponent<TMP_Text>();
        bossHealth = GameObject.Find("BossHealth").GetComponent<TMP_Text>();
        playerHealth = GameObject.Find("PlayerHealth").GetComponent<TMP_Text>();

        correctAns = GameObject.Find("CorrectPrompt");
        wrongAns = GameObject.Find("WrongPrompt");
        if (correctAns != null)
        {
            correctAns.SetActive(false);
        }
        if (wrongAns != null)
        {
            wrongAns.SetActive(false);
        }
        correctAns.SetActive(false);
        wrongAns.SetActive(false);
        ansBlock = transform.Find("AnsBlock");
        imageBlock = ansBlock.GetComponent<Image>();
        tryAgain = GameObject.Find("AnswerWrongPrompt");
        if(tryAgain != null)
        {
            tryAgain.SetActive(false);
        }
        submitButton = transform.Find("SubmitButton");
        loadButton = transform.Find("LoadScene");
        loadButton.gameObject.SetActive(false);

        speech = FindObjectOfType<IfSpeech>();
        if (speech != null)
        {
            speech.dialogue.SetActive(false);
        }
    }

    public void finalize()
    {
        //Transform check = temp.ansVertical;

        Transform check = GameObject.Find("AnsVLG")?.transform;
        Transform choicesBlock = GameObject.Find("VLG")?.transform;
        string ansText = prompt.text;
        int health_boss = int.Parse(bossHealth.text);
        int health_player = int.Parse(playerHealth.text);
        System.Random rnd = new System.Random();
        int ifIndex = -1; //gets the index of the if statement
        
        while(health_boss != 0)
        {
            int isStun = rnd.Next(0,2);
            if(isStun == 0) //not stunned
            {
                for(int i = 0; i < check.childCount; i++)
                {
                    TMP_Text checkText = check.GetChild(i).GetChild(0).GetComponent<TMP_Text>();
                    if(checkText != null )
                    {
                        string text = checkText.text;
                        if(text.Contains("bossStun == false"))
                        {
                            notStunnedChecker = true;
                            ifIndex = i;
                        }
                    }
                }
            }
            else if(isStun == 1) //stunned
            {
                for(int i = 0;i < check.childCount; i++)
                {
                    TMP_Text checkText = check.GetChild(i).GetChild(0).GetComponent<TMP_Text>();
                    if (checkText != null)
                    {
                        string text = checkText.text;
                        if (text.Contains("bossStun == true"))
                        {
                            isStunChecker = true;
                            ifIndex = i;
                        }
                    }
                }
            }
            if (isStunChecker && ifIndex != -1)
            {
                TMP_Text checkText;
                try
                {
                    checkText = check.GetChild(ifIndex + 1).GetChild(0).GetComponent<TMP_Text>();
                }
                catch (IndexOutOfRangeException e)
                {
                    Damaged = true;
                    health_player = health_player - 1;
                    playerHealth.text = health_player.ToString();
                    isStunChecker = false;
                    break;
                }
                catch(UnityException e)
                {
                    Damaged = true;
                    health_player = health_player - 1;
                    playerHealth.text = health_player.ToString();
                    isStunChecker = false;
                    break;
                }
                if (checkText != null)
                {
                    string text = checkText.text;
                    if(text.Contains("attack"))
                    {
                        health_boss = health_boss - 1;
                        bossHealth.text = health_boss.ToString();
                        isStunChecker = false;
                    }
                    else
                    {
                        health_player = health_player - 1;
                        playerHealth.text = health_player.ToString();
                        Damaged = true;
                        isStunChecker = false;
                        break;
                    }
                }
            }
            else if (notStunnedChecker && ifIndex != -1)
            {
                TMP_Text checkText;
                try
                {
                    checkText = check.GetChild(ifIndex + 1).GetChild(0).GetComponent<TMP_Text>();
                }
                catch(IndexOutOfRangeException e)
                {
                    Damaged = true;
                    health_player = health_player - 1;
                    playerHealth.text = health_player.ToString();
                    notStunnedChecker = false;
                    break;
                }
                catch(UnityException e)
                {
                    Damaged = true;
                    health_player = health_player - 1;
                    playerHealth.text = health_player.ToString();
                    notStunnedChecker = false;
                    break;
                }
                if( checkText != null )
                {
                    string text = checkText.text;
                    if (text.Contains("counter"))
                    {
                        health_boss = health_boss - 1;
                        bossHealth.text = health_boss.ToString();
                        notStunnedChecker = false;
                    }
                    else
                    {
                        health_player = health_player - 1;
                        playerHealth.text = health_player.ToString();
                        Damaged = true;
                        notStunnedChecker = false;
                        break;
                    }
                }
            }
        }

        if (Damaged)
        {
            /*List<Transform> temp = new List<Transform>();
            for(int i = 0; i < check.childCount; i++)
            {
                temp.Add(check.GetChild(i).transform);
            }
            foreach(Transform child in temp)
            {
                child.SetParent(choicesBlock, false);
            }
            Damaged = false;*/
            imageBlock.color = Color.red;
            tryAgain.SetActive(true);
        }

        if (health_player == 0 && health_boss != 0)
        {
            tryAgain.SetActive(false);
            wrongAns.SetActive(true);
            submitButton.gameObject.SetActive(false);
            loadButton.gameObject.SetActive(true);
        }
        else if (health_boss == 0 && health_player != 0)
        {
            tryAgain.SetActive(false);
            correctAns.SetActive(true);
            imageBlock.color = Color.green;

            //timer();
            submitButton.gameObject.SetActive(false);

            //SceneManager.LoadScene("Platform");
            loadButton.gameObject.SetActive(true);
            ifStatement = true;
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(4);
    }

    void OnDestroy()
    {
        Destroy(gameObject);
    }

    public void loadOverworld()
    {
        temp.badgeTempGone = false;
        SceneManager.LoadScene("Platform");
    }
}
