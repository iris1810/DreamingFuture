using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timerDuration = 3f * 60f;
    private float timer;

    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI seperator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;

    private void Start()
    {
        ResetTimer();
        UpdateTimerDisplay(timer); 
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
                timer = 0;

            UpdateTimerDisplay(timer);
        }
        else
        {
            Flash();
        }
    }

    private void ResetTimer()
    {
        timer = timerDuration;
    }

    private void UpdateTimerDisplay(float currentTimeValue)
    {
        int minutes = Mathf.FloorToInt(currentTimeValue / 60f);
        int seconds = Mathf.FloorToInt(currentTimeValue % 60f);

        string currentTime = string.Format("{0:00}{1:00}", minutes, seconds);

        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();

        if (seperator != null)
            seperator.text = ":";
    }

    private void Flash()
    {
        
    }
}