using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GoyaTimer : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float totalTime;
    [SerializeField] private Image headCapImage;
    [SerializeField] private Image tailCapImage;
    [SerializeField] private TMP_Text timerText;
    
    public float CurrentTime { get; private set; }
    private bool _isPaused;

    private void Update()
    {
        if (!_isPaused)
        {
            CurrentTime += Time.deltaTime;

            if (CurrentTime >= totalTime)
            {
                headCapImage.gameObject.SetActive(false);
                tailCapImage.gameObject.SetActive(false);
                _isPaused = true;
            }
            else
            {
                fillImage.fillAmount = (totalTime - CurrentTime) / totalTime;
                headCapImage.transform.localRotation = 
                    Quaternion.Euler(new Vector3(0, 0, fillImage.fillAmount * 360));
                
                var timeTextTime = totalTime - CurrentTime;
                timerText.text = timeTextTime.ToString("F0");
            }
        }
    }

    public void StartTimer()
    {
        _isPaused = false;
    }

    public void PauseTimer()
    {
        _isPaused = true;
    }

    public void RessetTimer()
    {
        CurrentTime = 0;
        fillImage.fillAmount = 1;
    }
}
