using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timerDuration = 2f * 60f;
    private float timer;

    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI seperator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;

    private bool isTimeUp = false;

    private void Start()
    {
        ResetTimer();
        UpdateTimerDisplay(timer);
    }

    private void Update()
    {
        if (isTimeUp) return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
                timer = 0;

            UpdateTimerDisplay(timer);
        }
        else
        {
            isTimeUp = true;
            StartCoroutine(GameOverSequence());
        }
    }

    private System.Collections.IEnumerator GameOverSequence()
    {
        // play sound
        SoundManager1.Play(SoundType1.GAME_OVER);

        yield return new WaitForSeconds(0.8f); // wait a second

        // change scene
        SceneManager.LoadScene("Lose");
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
        // optional
    }
}