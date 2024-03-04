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

        prompt = GameObject.Find("Prompt")?.GetComponent<TMP_Text>();

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
        }

        if (transform.position.x >= leftAns && transform.position.x <= rightAns && dragging == false)
        {
            gameObject.transform.SetParent(ansVertical, false);
        }
        else if (dragging == false && transform.position.x >= leftEdge && transform.position.x <= leftAns)
        {
            gameObject.transform.SetParent(checkvlg, false);
        }     
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