using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour
{
    public SerchMg serchMgn;

    [SerializeField]
    private GameObject checkIcon;           // 체크 이미지

    [SerializeField]
    private Image hintCircle;               // 힌트 이미지

    

    public void Check()
    {
        // 틀린 그림 버튼 클릭 시 serchMgn 호출
        serchMgn.Serch(1);

        // 체크 이미지 출력된 뒤 해당 위치에 있는 힌트 이미지 색상 변경
        checkIcon.gameObject.SetActive(true);

        hintCircle.color = new Color(0, 0, 0, 0);

        // 해당 오브젝트 비활성화
        this.gameObject.SetActive(false);
    }
}
