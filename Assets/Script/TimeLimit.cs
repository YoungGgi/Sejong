using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    public float timelimit;             // 타이머

    [SerializeField]
    private Text timeText;              // 타이머 텍스트

    [SerializeField]
    private GameObject OverPanel;        // 게임 오버 오브젝트


    private void Start()
    {
        // 타이머 변수를 ToString() 으로 타이머 텍스트로 할당
        timeText.text = timelimit.ToString();
    }

    private void Update()
    {
        // 시간마다 타이머의 숫자가 줄어듦
        if (timelimit > 0)
        {
            timelimit -= Time.deltaTime;
        }
        else if (timelimit < 0)
        {
            // 타이머가 0이 되면 게임 오버 오브젝트 활성화
            Time.timeScale = 0.0f;
            OverPanel.gameObject.SetActive(true);
        }

        // 타이머가 10초 전일 시 컬러 붉은색으로 변경
        if (timelimit < 10)
            timeText.color = new Color(255, 0, 0);

        // Mathf.Round() 를 이용해 타이머 텍스트 부드럽게 변경
        timeText.text = Mathf.Round(timelimit).ToString();
    }

    

}
