using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image fillImage;
    public float fillSpeed = 0.5f;
    public int maxProgress = 15;
    private int currentProgress = 0;
    public TextMeshProUGUI winText;


    void Start()
    {
        winText.gameObject.SetActive(false);
        SetProgress(0);
    }

    //进度条增长
    public void SetProgress(int progress)
    {
        currentProgress = progress;
        float fillAmount = (float)progress / maxProgress;
        fillImage.fillAmount = fillAmount;

        
    }

    public void AddProgress()
    {
        if (currentProgress < maxProgress)
        {
            currentProgress++;
            float fillAmount = (float)currentProgress / maxProgress;
            StartCoroutine(FillImage(fillAmount));
        }
        if (currentProgress == maxProgress)
        {
            winText.gameObject.SetActive(true);
        }

    }
    //not fully understood
    IEnumerator FillImage(float fillAmount)
    {
        float elapsedTime = 0;
        float startFillAmount = fillImage.fillAmount;
        while (elapsedTime < fillSpeed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fillSpeed);
            fillImage.fillAmount = Mathf.Lerp(startFillAmount, fillAmount, t);
            yield return null;
        }
    }
}