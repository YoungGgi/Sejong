using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    [Header("메인 타이틀 화면")]
    [SerializeField]
    private GameObject PausePanel;              // 일시정지 그룹

    [SerializeField]
    private GameObject ExitPanel;               // 게임종료 그룹

    [SerializeField]
    private GameObject helpPanel;               // 게임 도움말 그룹

    [SerializeField]
    private GameObject gameHelp;                // 게임 도움말 1

    [SerializeField]
    private GameObject gameHelpImage2;          // 게임 도움말 2

    [SerializeField]
    private GameObject gameHelpImage3;          // 게임 도움말 3

    [SerializeField]
    private GameObject ExitBtn;                 // 나가기 버튼

    [SerializeField]
    private GameObject HelpBtn;                 // 게임방법 버튼


    [Header("인게임")]
    [SerializeField]
    private GameObject hintbox;                 // 힌트 오브젝트 그룹

    [SerializeField]
    private GameObject hintBtn;                 // 힌트 버튼

    [SerializeField]
    private GameObject ExtraPanel;              // 엑스트라 스테이지 판넬(4스테이지 전용)

    [SerializeField]
    private GameObject clearPanel4;             // 게임 클리어 판넬(4스테이지 전용)

    public TimeLimit timeLimit;                 // 제한시간 전용 클래스

    // 오디오소스와 효과음
    public AudioSource audioSource;
    public AudioClip sfxClip;

    [SerializeField]
    private AudioClip hintClip;                 // 힌트 효과음

    private void Start()
    {
        StopAllCoroutines();
        audioSource = GetComponent<AudioSource>();
    }

    #region StartScene
    public void StageIn()             // 게임 시작 함수
    {
        audioSource.PlayOneShot(sfxClip);

        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public IEnumerator gameStart()           // 게임 로딩 코루틴
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(1);
    }
    #endregion StartScene


    #region NextStageScene
    public void NextStageIn()              // 2 스테이지 이동 함수
    {
        audioSource.PlayOneShot(sfxClip);

        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Next3Stage()              // 3 스테이지 이동 함수
    {
        audioSource.PlayOneShot(sfxClip);

        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void Next4Stage()              // 4 스테이지 이동 함수
    {
        audioSource.PlayOneShot(sfxClip);

        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    public void Next5Stage()              // 엑스트라 스테이지 이동 함수
    {
        audioSource.PlayOneShot(sfxClip);

        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }

    #endregion NextStageScene


    #region OverScene
    public void MainSceneIn()              // 메인 화면으로 이동하는 함수, 로딩 코루틴
    {
        audioSource.PlayOneShot(sfxClip);

        StartCoroutine(mainScene());
        Time.timeScale = 1f;
    }

    public IEnumerator mainScene()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }
    #endregion OverScene

    public void Re1Stage()                 // 1 스테이지 재시작 함수
    {
        audioSource.PlayOneShot(sfxClip);

        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        timeLimit.timelimit = 60.0f;
    }

    public void Re2Stage()                // 2 스테이지 재시작 함수
    {
        audioSource.PlayOneShot(sfxClip);

        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        timeLimit.timelimit = 60.0f;
    }

    public void Re3Stage()                // 3 스테이지 재시작 함수
    {
        audioSource.PlayOneShot(sfxClip);

        SceneManager.LoadScene(3);
        Time.timeScale = 1;
        timeLimit.timelimit = 60.0f;
    }

    public void Re4Stage()               // 4 스테이지 재시작 함수
    {
        audioSource.PlayOneShot(sfxClip);

        SceneManager.LoadScene(4);
        Time.timeScale = 1;
        timeLimit.timelimit = 60.0f;
    }

    public void Re5Stage()              // 엑스트라 스테이지 재시작 함수(폐기예정)
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
        timeLimit.timelimit = 60.0f;
    }

    public void Pause()                         // 일시정지 함수
    {
        audioSource.PlayOneShot(sfxClip);

        PausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseOut()                      // 일시정지 해제 함수
    {
        audioSource.PlayOneShot(sfxClip);

        PausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitStage()                     // 게임 진행 중 나가기 함수
    {
        audioSource.PlayOneShot(sfxClip);

        SceneManager.LoadScene(0);
    }

    public void ExitPopUp()                     // 게임 종료 팝업 호출 함수
    {
        audioSource.PlayOneShot(sfxClip);

        ExitPanel.gameObject.SetActive(true);
    }

     public void GameQuit()                     // 게임 종료 함수
    {
        audioSource.PlayOneShot(sfxClip);

        Application.Quit();
    }


    public void NoExit()                       // 게임 종료 팝업 비활성화 함수
    {
        audioSource.PlayOneShot(sfxClip);

        ExitPanel.gameObject.SetActive(false);
    }

    public void helpOn()
    {
        audioSource.PlayOneShot(sfxClip);
        
        helpPanel.gameObject.SetActive(true);
        ExitBtn.gameObject.SetActive(false);
        HelpBtn.gameObject.SetActive(false);
    }

    public void helpOff()
    {
        audioSource.PlayOneShot(sfxClip);

        helpPanel.gameObject.SetActive(false);
        ExitBtn.gameObject.SetActive(true);
        HelpBtn.gameObject.SetActive(true);
    }
    

    public void HintOn()                    // 힌트 활성화 함수
    {
        audioSource.PlayOneShot(hintClip);

        hintbox.gameObject.SetActive(true);

        StartCoroutine("HintDelay");

        hintBtn.gameObject.SetActive(false);

    }

    IEnumerator HintDelay()                // 힌트 딜레이 코루틴
    {
        yield return new WaitForSeconds(1.5f);

        hintbox.gameObject.SetActive(false);
    }

    public void ExtraImgOn()              // 엑스트라 스테이지 팝업 호출
    {
        audioSource.PlayOneShot(sfxClip);

        ExtraPanel.gameObject.SetActive(true);
        clearPanel4.gameObject.SetActive(false);


    }

    public void SfxOn()                   // 효과음 재생 함수
    {
        audioSource.PlayOneShot(sfxClip);
    }

}
