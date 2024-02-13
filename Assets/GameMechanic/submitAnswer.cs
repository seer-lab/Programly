using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading;

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
    // Start is called before the first frame update
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
            List<Transform> temp = new List<Transform>();
            for(int i = 0; i < check.childCount; i++)
            {
                temp.Add(check.GetChild(i).transform);
            }
            foreach(Transform child in temp)
            {
                child.SetParent(choicesBlock, false);
            }
            Damaged = false;
        }

        /*for (int i = 0; i < check.childCount - 1; i++)
        {
            //string text = check.GetChild(i).GetComponent<TextMeshProUGUI>().text;
            TMP_Text checktext = check.GetChild(i).GetChild(0).GetComponent<TMP_Text>();
            if (checktext != null)
            {
                string text = checktext.text;
                Debug.Log(text);
                //if (text == "action = attack();")
                //{
                    //checking = true;
                    //break;
                //}
                if (ansText.Contains("Dodge"))
                {
                    char num = ansText[6];
                    if (text == "action = dodge();")
                    {
                        TMP_Text checkans = check.GetChild(i + 1).GetChild(0).GetComponent<TMP_Text>();
                        if (checkans != null)
                        {
                            string tempcheck = checkans.text;
                            if (tempcheck.Contains(num))
                            {
                                checking = true;
                                answered = true;
                                break;
                            }
                        }
                    }
                }
                else if (ansText.Contains("Attack"))
                {
                    char num = ansText[7];
                    if (text == "action = attack();")
                    {
                        TMP_Text checkans = check.GetChild(i + 1).GetChild(0).GetComponent<TMP_Text>();
                        if (checkans != null)
                        {
                            string tempcheck = checkans.text;
                            if (tempcheck.Contains(num))
                            {
                                checking = true;
                                answered = true;
                                break;
                            }
                        }
                    }
                }
                else if (ansText.Contains("Heal"))
                {
                    char num = ansText[5];
                    if (text == "action = heal();")
                    {
                        TMP_Text checkans = check.GetChild(i + 1).GetChild(0).GetComponent<TMP_Text>();
                        if (checkans != null)
                        {
                            string tempcheck = checkans.text;
                            if (tempcheck.Contains(num))
                            {
                                checking = true;
                                answered=true;
                                Debug.Log(num);
                                break;
                            }
                        }
                    }
                }
            }
        }*/

        if (health_player == 0 && health_boss != 0)
        {
            wrongAns.SetActive(true);
        }
        else if (health_boss == 0 && health_player != 0)
        {
            correctAns.SetActive(true);
        }
    }
}
