using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEditor.SceneManagement;

namespace Lee
{
    public class SaveSlot : MonoBehaviour
    {
       //public GameObject creat;    // 플레이어 닉네임 입력UI
       //public TMP_Text[] slotText;     // 슬롯버튼 아래에 존재하는 Text들
       //public TMP_Text newPlayerName;	// 새로 입력된 플레이어의 닉네임
       //
       //bool[] savefile = new bool[3];	// 세이브파일 존재유무 저장
       //
       //void Start()
       //{
       //    // 슬롯별로 저장된 데이터가 존재하는지 판단.
       //    for (int i = 0; i < 3; i++)
       //    {
       //        if (File.Exists(SaveManager_Json.instance.savePath + $"{i}"))    // 데이터가 있는 경우
       //        {
       //            savefile[i] = true;         // 해당 슬롯 번호의 bool배열 true로 변환
       //            SaveManager_Json.instance.nowSlot = i;   // 선택한 슬롯 번호 저장
       //            SaveManager_Json.instance.LoadData();    // 해당 슬롯 데이터 불러옴
       //            slotText[i].text = SaveManager_Json.instance.nowPlayer.name; // 버튼에 닉네임 표시
       //        }
       //        else    // 데이터가 없는 경우
       //        {
       //            slotText[i].text = "비어있음";
       //        }
       //    }
       //    // 불러온 데이터를 초기화시킴.(버튼에 닉네임을 표현하기위함이었기 때문)
       //    SaveManager_Json.instance.DataClear();
       //}
       //
       //public void Slot(int number)    // 슬롯의 기능 구현
       //{
       //    SaveManager_Json.instance.nowSlot = number;  // 슬롯의 번호를 슬롯번호로 입력함.
       //
       //    if (savefile[number])   // bool 배열에서 현재 슬롯번호가 true라면 = 데이터 존재한다는 뜻
       //    {
       //        SaveManager_Json.instance.LoadData();    // 데이터를 로드하고
       //        LoadButton();   // 게임씬으로 이동
       //    }
       //    else    // bool 배열에서 현재 슬롯번호가 false라면 데이터가 없다는 뜻
       //    {
       //        Creat();    // 플레이어 닉네임 입력 UI 활성화
       //    }
       //}
       //
       //public void Creat() // 플레이어 닉네임 입력 UI를 활성화하는 메소드
       //{
       //    creat.gameObject.SetActive(true);
       //}
       //
       //public void LoadButton()    // 게임씬으로 이동
       //{
       //    if (!savefile[SaveManager_Json.instance.nowSlot])    // 현재 슬롯번호의 데이터가 없다면
       //    {
       //        SaveManager_Json.instance.nowPlayer.name = newPlayerName.text; // 입력한 이름을 복사해옴
       //        SaveManager_Json.instance.SaveData(); // 현재 정보를 저장함.
       //    }
       //    SaveManager_Json.instance.LoadData();
       //}
        
    }
}
