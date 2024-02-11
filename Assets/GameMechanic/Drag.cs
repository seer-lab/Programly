using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Drag : EventTrigger
{
    private bool dragging = false;
    private Vector3 offset;
    private Transform ansVertical;
    private RectTransform vlg;
    private Transform checkvlg;
    private RectTransform ansVLGRect;
    private bool setParent = false;
    private float leftEdge;
    private float rightEdge;
    private float leftAns;
    private float rightAns;
    private float origPosX;
    private float origPosY;

    private bool isAttack = false;
    private bool isDodge = false;
    private bool isHeal = false;

    private Transform attackChoices;
    private Transform defendChoices;
    private Transform healChoices;

    private TMP_Text prompt;
    private bool assembled = false;
    private TMP_Text button;
    private RectTransform buttonTransform;

    private void Start()
    {
        ansVertical = GameObject.Find("AnsVLG")?.transform;
        ansVLGRect = GameObject.Find("AnsVLG")?.GetComponent<RectTransform>();
        vlg = GameObject.Find("VLG")?.GetComponent<RectTransform>();
        checkvlg = GameObject.Find("VLG")?.transform;

        origPosX = transform.position.x;
        origPosY = transform.position.y;

        //temp = GameObject.Find("PreFabSample")?.transform;


        attackChoices = GameObject.Find("AttackCommands")?.transform;
        defendChoices = GameObject.Find("DodgeCommands")?.transform;
        healChoices = GameObject.Find("HealCommands")?.transform;

        prompt = GameObject.Find("Prompt")?.GetComponent<TMP_Text>();

        /*if(button == null)
        {
            button = GetComponent<TMP_Text>();
            if(button  == null)
            {
                Debug.LogError("Button not found");
                return;
            }
        }

        buttonTransform = button.rectTransform;*/
        //Vector3 buttonPos = buttonTransform.position;

    }

    // Update is called once per frame
    private void Update()
    {
        string word = prompt.text;

        leftEdge = vlg.position.x - vlg.rect.width * 0.5f;
        rightEdge = vlg.position.x + vlg.rect.width * 0.5f;

        leftAns = ansVLGRect.position.x - ansVLGRect.rect.width * 0.5f;
        rightAns = ansVLGRect.position.x + ansVLGRect.rect.width * 0.5f;


        if (dragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //gameObject.transform.SetParent(temp, false);

        }

        if (transform.position.x >= leftAns && transform.position.x <= rightAns && dragging == false)
        {
            gameObject.transform.SetParent(ansVertical, false);
        }
        else if (dragging == false && transform.position.x >= leftEdge && transform.position.x <= leftAns)
        {
            gameObject.transform.SetParent(checkvlg, false);
        }

        /*if (word.Contains("Attack") && assembled == false)
        {
            isAttack = false; //temp change
            isDodge = false;
            isHeal = true;
            assembled = true;
        }
        else if (word.Contains("Dodge") && assembled == false)
        {
            isAttack = false;
            isDodge = false; //temp change
            isHeal = true;
            assembled = true;
        }
        else if (word.Contains("Heal") && assembled == false)
        {
            isAttack = false;
            isDodge = false;
            isHeal = true;
            assembled = true;
        }


        if(isAttack && assembled == true)
        {
            for(int i = 0; i < attackChoices.childCount; i++)
            {
                attackChoices.GetChild(i).gameObject.transform.SetParent(checkvlg, false);
            }
            isAttack = false;
        }

        else if(isDodge && assembled == true)
        {
            for (int i = 0; i < defendChoices.childCount; i++)
            {
                defendChoices.GetChild(i).gameObject.transform.SetParent(checkvlg, false);
            }
            isDodge = false;
        }

        else if(isHeal && assembled == true)
        {
            for (int i = 0; i < healChoices.childCount; i++)
            {
                healChoices.GetChild(i).gameObject.transform.SetParent(checkvlg, false);
            }
            isHeal = false;
        }*/


        /*if(dragging == false && checkvlg.childCount > 1)
        {
            int location = gameObject.transform.GetSiblingIndex();
            Transform current = gameObject.transform;
            int target = location;
            Transform temp = null;

            for(int i = 0; i < checkvlg.childCount; i++)
            {
                if(gameObject.transform.position.y  > checkvlg.GetChild(i).position.y)
                {
                    target = i;
                    break;
                }
            }
            for (int i = location; i > target; i--)
            {
                temp = checkvlg.GetChild(i);
                temp.SetSiblingIndex(i+1);
            }
            //temp.gameObject.transform.SetSiblingIndex(target);
            if (temp != null)
            {
                temp.SetSiblingIndex(target);
            }
        }*/

        /*if (dragging == false && ansVertical.childCount > 1)
        {
            int location = transform.GetSiblingIndex();
            int target = location;
            Transform temp = null;

            Debug.Log("This is the location " + location);
            Transform temp;
            int oldIndex = -1;
            for (int i = 0; i < ansVertical.childCount; i++)
            {
                if(gameObject.transform.position.y == ansVertical.GetChild(i).position.y)
                {
                    oldIndex = i;
                }
                if (gameObject.transform.position.y > ansVertical.GetChild(i).position.y)// || gameObject.transform.position.y < ansVertical.GetChild(i).position.y)
                {
                    temp = ansVertical.GetChild(i);
                    gameObject.transform.SetSiblingIndex(i);
                    temp.SetSiblingIndex(oldIndex);
                }
            }
        }*/
        

    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}