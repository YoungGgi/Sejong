using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerchMg : MonoBehaviour
{
    [SerializeField]
    private Text serch;                       // 찾은 개수 출력할 텍스트

    [SerializeField]
    private int serchNum;                     // 스테이지 별 찾은 개수

    [SerializeField]
    private int maxSerchNum;                  // 스테이지 별 찾아야 하는 총 개수

    [SerializeField]
    private GameObject ClearPanel;            // 게임 클리어 오브젝트

    [SerializeField]
    private AudioSource audioSource;          // 오디오 소스

    [SerializeField]
    private AudioClip sfxClip;                // 효과음


    private void Start()
    {
        // 텍스트에 스테이지 별 찾은 개수 / 찾아야 하는 총 개수 할당
        serch.text = serchNum + " / " + maxSerchNum;

        audioSource = GetComponent<AudioSource>();

    }

    public void Serch(int num)
    {
        audioSource.PlayOneShot(sfxClip);

        // 틀린 그림 찾았을 시 serchNum 증가
        serchNum += num;
        serch.text = serchNum + " / " + maxSerchNum;

        // 틀린 그림을 전부 찾았을 시 Clear() 코루틴 실행
        if (serchNum == maxSerchNum)
            StartCoroutine(Clear());
    }

    public IEnumerator Clear()
    {
        yield return new WaitForSeconds(1f);

        Time.timeScale = 0.0f;
        ClearPanel.gameObject.SetActive(true);

    }



}
