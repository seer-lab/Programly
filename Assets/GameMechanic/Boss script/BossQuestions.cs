using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossQuestions : MonoBehaviour
{
    [SerializeField] private List<Question> question = new List<Question>();
    private TMP_Text prompt;
    private int index;
    private TMP_Text playerHealth;
    private TMP_Text bossHealth;
    private System.Random rnd;
    private bool correct = false;

    [SerializeField] private Transform vlg;
    [SerializeField] private Transform checkVLG;
    [SerializeField] private Image block;
    private bossSpeech bossDialogue;

    [SerializeField] private Transform button;
    [SerializeField] private Transform submit;
    [SerializeField] private Transform dead;

    private GameObject player;
    private interactVillager temp;

    void Awake()
    {
        question.Add(new Question("Program an if statement that will attack once boss is tired and counter if not"));
        question.Add(new Question("Program an if statement that will attack if boss is stunned and counter if not"));
        question.Add(new Question("Program a for loop that attacks the boss 5 times"));
        question.Add(new Question("Program a for loop that attacks the boss 2 times"));
        question.Add(new Question("Quickly assign your action with a shield of type string to dodge the attack"));
        question.Add(new Question("Quickly assign the dodge with the type of int a value of 4 to dodge the enemy's attack"));
        player = GameObject.Find("Player");
        temp = player.GetComponent<interactVillager>();
    }

    void Start()
    {
        prompt = GameObject.Find("Prompt").GetComponent<TMP_Text>();
        playerHealth = GameObject.Find("playerHealth").GetComponent<TMP_Text>();
        bossHealth = GameObject.Find("bossHealth").GetComponent<TMP_Text>();
        bossDialogue = FindObjectOfType<bossSpeech>();
        {
            if(bossDialogue != null)
            {
                bossDialogue.dialogue.SetActive(false);
            }
        }

        button.gameObject.SetActive(false);
        dead.gameObject.SetActive(false);
        rnd = new System.Random();
        index = rnd.Next(0, question.Count);
        prompt.text = question[index].prompt;
        changeButtonString(vlg, index);
    }

    // Update is called once per frame
    void Update()
    {
        int boss_health = int.Parse(bossHealth.text);
        int player_health = int.Parse(playerHealth.text);
        if (correct == true)
        {
            List<Transform> temp = new List<Transform>();
            for (int i = 0; i < checkVLG.childCount; i++)
            {
                temp.Add(checkVLG.GetChild(i).transform);
            }
            foreach (Transform child in temp)
            {
                child.SetParent(vlg, false);
            }
            index = rnd.Next(0, question.Count);
            while(question[index].completed == true)
            {
                index = rnd.Next(0, question.Count);
            }
            changeButtonString(vlg, index);
            prompt.text = question[index].prompt;
            correct = false;
        }

        if (player_health == 0 || boss_health == 0)
        {
            if(player_health == 0)
            {
                dead.gameObject.SetActive(true);
            }
            else
            {
                button.gameObject.SetActive(true);
            }
            submit.gameObject.SetActive(false);
        }
    }

    public void finalize()
    {
        int boss_health = int.Parse(bossHealth.text);
        int player_health = int.Parse(playerHealth.text);


        if (boss_health > 0 || player_health > 0)
        {
            Debug.Log(question[index].completed);
            if (question[index].completed == false)
            {
                prompt.text = question[index].prompt;
                while (player_health > 0)
                {
                    if (index == 0 || index == 1) //if statement question
                    {
                        if (index == 0)
                        {
                            for(int i = 0; i < checkVLG.childCount; i++)
                            {
                                TMP_Text checkText = checkVLG.GetChild(i).GetChild(0).GetComponent<TMP_Text>();
                                string text = checkText.text;
                                if (i == 0 && !text.Contains("bossTired == true"))
                                {
                                    correct = false;
                                    break;
                                }
                                else if (i == 1 && !text.Contains("attack"))
                                {
                                    correct = false;
                                    break;
                                }
                                else if(i == 2 && !text.Contains("else"))
                                {
                                    correct = false;
                                    break;
                                }
                                else if(i == 3 && !text.Contains("counter"))
                                {
                                    correct = false;
                                    break;
                                }
                                correct = true;
                            }
                            if(correct == false)
                            {
                                Damaged(player_health, false);
                                break;
                            }
                            else if(correct == true)
                            {
                                Damaged(boss_health, true);
                                question[index].completed = true;
                                break;
                            }
                        }

                        else if (index == 1)
                        {
                            for (int i = 0; i < checkVLG.childCount; i++)
                            {
                                TMP_Text checkText = checkVLG.GetChild(i).GetChild(0).GetComponent<TMP_Text>();
                                string text = checkText.text;
                                if (i == 0 && !text.Contains("bossStun == true"))
                                {
                                    correct = false;
                                    break;
                                }
                                else if (i == 1 && !text.Contains("attack"))
                                {
                                    correct = false;
                                    break;
                                }
                                else if (i == 2 && !text.Contains("else"))
                                {
                                    correct = false;
                                    break;
                                }
                                else if (i == 3 && !text.Contains("counter"))
                                {
                                    correct = false;
                                    break;
                                }
                                correct = true;
                            }
                            if (correct == false)
                            {
                                Damaged(player_health, false);
                                break;
                            }
                            else if (correct == true)
                            {
                                Damaged(boss_health, true);
                                question[index].completed = true;
                                break;
                            }
                        }
                    }

                    else if (index == 2 || index == 3) // for loop question
                    {
                        if (index == 2)
                        {
                            //18
                            for(int i = 0; i < checkVLG.childCount; i++)
                            {
                                TMP_Text checkText = checkVLG.GetChild(i).GetChild(0).GetComponent<TMP_Text>();
                                string text = checkText.text;
                                if(i == 0 && !text.Contains("5"))
                                {
                                    correct = false;
                                    break;
                                }
                                else if(i == 1 && !text.Contains("attack"))
                                {
                                    correct = false;
                                    break;
                                }
                                correct = true;
                            }
                            if(correct == false)
                            {
                                Damaged(player_health, correct);
                                break;
                            }
                            else if(correct == true)
                            {
                                Damaged(boss_health, correct);
                                question[index].completed = true;
                                break;
                            }
                        }

                        else if (index == 3)
                        {
                            for (int i = 0; i < checkVLG.childCount; i++)
                            {
                                TMP_Text checkText = checkVLG.GetChild(i).GetChild(0).GetComponent<TMP_Text>();
                                string text = checkText.text;
                                if (i == 0 && !text.Contains("2"))
                                {
                                    correct = false;
                                    break;
                                }
                                else if (i == 1 && !text.Contains("attack"))
                                {
                                    correct = false;
                                    break;
                                }
                                correct = true;
                            }
                            if (correct == false)
                            {
                                Damaged(player_health, correct);
                                break;
                            }
                            else if (correct == true)
                            {
                                Damaged(boss_health, correct);
                                question[index].completed = true;
                                break;
                            }
                        }
                    }

                    else if (index == 4 || index == 5) //assign statement question
                    {
                        if (index == 4)
                        {
                            TMP_Text checkText = checkVLG.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
                            string text = checkText.text;
                            if (text != "string action = \"shield\"")
                            {
                                correct = false;
                                Damaged(player_health, correct);
                                break;
                            }
                            else
                            {
                                correct = true;
                                Damaged(boss_health, correct);
                                question[index].completed = true;
                                break;
                            }
                        }

                        else if (index == 5)
                        {
                            TMP_Text checkText = checkVLG.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
                            string text = checkText.text;
                            if (text != "int dodge = 4")
                            {
                                correct = false;
                                Damaged(player_health, correct);
                                break;
                            }
                            else
                            {
                                correct = true;
                                Damaged(boss_health, correct);
                                question[index].completed = true;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    void Damaged(int health, bool correct)
    {
        health = health - 1;
        if (correct == true)
        {
            bossHealth.text = health.ToString();
            block.color = Color.green;
        }
        else if(correct == false)
        {
            playerHealth.text = health.ToString();
            block.color = Color.red;
        }
    }

    public void loadEnvironment()
    {
        temp.badgeTempGone = false;
        SceneManager.LoadScene("Platform");
    }

    void changeButtonString(Transform vlg, int index)
    {
        for (int i = 0; i < vlg.childCount; i++)
        {
            TMP_Text checkText = vlg.GetChild(i).GetChild(0).GetComponent<TMP_Text>();
            if (index == 0)
            {
                if (i == 0)
                {
                    checkText.text = "if(bossTired == true)";
                }

                else if (i == 1)
                {
                    checkText.text = "counter()";
                }

                else if (i == 2)
                {
                    checkText.text = "else";
                }

                else if (i == 3)
                {
                    checkText.text = "attack()";
                }
            }

            else if (index == 1)
            {
                if (i == 0)
                {
                    checkText.text = "if(bossStun == true)";
                }

                else if (i == 1)
                {
                    checkText.text = "counter()";
                }

                else if (i == 2)
                {
                    checkText.text = "else";
                }

                else if (i == 3)
                {
                    checkText.text = "attack()";
                }
            }

            else if (index == 2)
            {
                if (i == 0)
                {
                    checkText.text = "for(int i = 0; i < 3; i++)";
                }

                else if (i == 1)
                {
                    checkText.text = "for(int i = 0; i < 5; i++)";
                }

                else if (i == 2)
                {
                    checkText.text = "for(int i = 0; i < 4; i++)";
                }

                else if (i == 3)
                {
                    checkText.text = "attack()";
                }
            }

            else if (index == 3)
            {
                if (i == 0)
                {
                    checkText.text = "for(int i = 0; i < 3; i++)";
                }

                else if (i == 1)
                {
                    checkText.text = "attack()";
                }

                else if (i == 2)
                {
                    checkText.text = "for(int i = 0; i < 2; i++)";
                }

                else if (i == 3)
                {
                    checkText.text = "for(int i = 0; i < 1; i++)";
                }
            }

            else if (index == 4)
            {
                if (i == 0)
                {
                    checkText.text = "string action = 5";
                }

                else if (i == 1)
                {
                    checkText.text = "string action = shield";
                }

                else if (i == 2)
                {
                    checkText.text = "string action = 7";
                }

                else if (i == 3)
                {
                    checkText.text = "string action = \"shield\"";
                }
            }

            else if (index == 5)
            {
                if (i == 0)
                {
                    checkText.text = "int dodge = 4";
                }

                else if (i == 1)
                {
                    checkText.text = "int dodge = 3";
                }

                else if (i == 2)
                {
                    checkText.text = "int dodge = \"3\"";
                }

                else if (i == 3)
                {
                    checkText.text = "int action = \"4\"";
                }
            }
        }
    }
}
