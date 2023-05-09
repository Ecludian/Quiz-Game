using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DragnDropQuestion
{
    public string question;

    //ANSWER 1
    [System.Serializable]
    public class Answer1 
    {
        public string answer1;
        public bool isCorrect;
    }
    public Answer1 answer1 = new Answer1();

    //ANSWER 2
    [System.Serializable]
    public class Answer2
    {
        public string answer2;
        public bool isCorrect;
    }
    public Answer2 answer2 = new Answer2();

    //ANSWER 3
    [System.Serializable]
    public class Answer3
    {
        public string answer3;
        public bool isCorrect;
    }
    public Answer3 answer3 = new Answer3();

    //ANSWER 4
    [System.Serializable]
    public class Answer4
    {
        public string answer4;
        public bool isCorrect;
        
    }
    public Answer4 answer4 = new Answer4();

    public Sprite image;

    
}
