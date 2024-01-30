using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class submitAnswer : MonoBehaviour
{
    private bool checking = false;
    private TMP_Text prompt;
    // Start is called before the first frame update
    void Start()
    {
        prompt = GameObject.Find("Prompt").GetComponent<TMP_Text>();
    }

    public void finalize()
    {
        //Transform check = temp.ansVertical;

        Transform check = GameObject.Find("AnsVLG")?.transform;
        string ansText = prompt.text;

        for (int i = 0; i < check.childCount; i++)
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
                                break;
                            }
                        }
                    }
                }
                else if (ansText.Contains("Attack"))
                {
                    char num = ansText[6];
                    if (text == "action = attack();")
                    {
                        TMP_Text checkans = check.GetChild(i + 1).GetChild(0).GetComponent<TMP_Text>();
                        if (checkans != null)
                        {
                            string tempcheck = checkans.text;
                            if (tempcheck.Contains(num))
                            {
                                checking = true;
                                break;
                            }
                        }
                    }
                }
                else if (ansText.Contains("Heal"))
                {
                    char num = ansText[6];
                    if (text == "action = heal();")
                    {
                        TMP_Text checkans = check.GetChild(i + 1).GetChild(0).GetComponent<TMP_Text>();
                        if (checkans != null)
                        {
                            string tempcheck = checkans.text;
                            if (tempcheck.Contains(num))
                            {
                                checking = true;
                                break;
                            }
                        }
                    }
                }
            }
        }
        if (checking)
        {
            Debug.Log("Answer is correct!!!!!!!!!!!!");
            checking = false;
        }
        else
        {
            Debug.Log("Answer is wrong!!!!!!!!!");
        }
    }
}
