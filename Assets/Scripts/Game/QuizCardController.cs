using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public struct QuizData
{
    public string question;
    public string description;
    public int type;
    public int answer;
    public string[] options;
}

public class QuizCardController : MonoBehaviour
{
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text[] optionTexts;
    
    public delegate void QuizCardDelegate(int cardIndex);
    private event QuizCardDelegate onCompleted;
    
    public void SetQuiz(QuizData quizData, QuizCardDelegate onCompleted)
    {
        // 1. 퀴즈
        // 2. 설명
        // 3. 타입 (0: OX퀴즈, 1: 보기 3개 객관식)
        // 4. 정답
        // 5. 보기 (1,2,3)
         
        
        // 퀴즈 데이터 표현
        questionText.text = quizData.question;
        descriptionText.text = quizData.description;
        for (int i = 0; i < optionTexts.Length; i++)
        {
            optionTexts[i].text = quizData.options[i];
        }
        
        this.onCompleted = onCompleted;
    }
}
