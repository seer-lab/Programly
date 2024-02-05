using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class submitAnswer : MonoBehaviour
{
    private bool checking = false;
    private TMP_Text prompt;
    public int correct = 0;
    private bool answered = false;

    private GameObject correctAns;
    private GameObject wrongAns;
    // Start is called before the first frame update
    void Start()
    {
        prompt = GameObject.Find("Prompt").GetComponent<TMP_Text>();

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
        string ansText = prompt.text;

        for (int i = 0; i < check.childCount - 1; i++)
        {
            //string text = check.GetChild(i).GetComponent<TextMeshProUGUI>().text;
            TMP_Text checktext = check.GetChild(i).GetChild(0).GetComponent<TMP_Text>();
            if (checktext != null)
            {
                string text = checktext.text;
                Debug.Log(text);
                /*if (text == "action = attack();")
                {
                    checking = true;
                    break;
                }*/
                if (ansText.Contains("Block"))
                {
                    char num = ansText[6];
                    if (text == "action = defend();")
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
        }
        if (checking == true && answered == true)
        {
            Debug.Log("Answer is correct!!!!!!!!!!!!");
            checking = false;
            correctAns.SetActive(true);
        }
        else
        {
            Debug.Log("Answer is wrong!!!!!!!!!");
            correct = 2;
            wrongAns.SetActive(true);
        }
    }
}
