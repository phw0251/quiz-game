using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelController : MonoBehaviour
{
    [SerializeField] private GameObject quizCardPrefab;                        // Quiz Card Prefab
    [SerializeField] private Transform quizCardParent;                         // Quiz Card가 표시될 UI Parent
    
    private void Start()
    {
        ShowQuizCard();
    }

    private void ShowQuizCard()
    {
        var quizCardObject = Instantiate(quizCardPrefab, quizCardParent);
    }
    
    public void OnClickGameOverButton()
    {
        GameManager.Instance.QuitGame();
    }
}
