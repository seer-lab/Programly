using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public string prompt;
    public bool completed = false;
   

    public Question(string prompt)
    {
        this.prompt = prompt;
        this.completed = false;
    }
    
}
