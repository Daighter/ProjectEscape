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
       //public GameObject creat;    // �÷��̾� �г��� �Է�UI
       //public TMP_Text[] slotText;     // ���Թ�ư �Ʒ��� �����ϴ� Text��
       //public TMP_Text newPlayerName;	// ���� �Էµ� �÷��̾��� �г���
       //
       //bool[] savefile = new bool[3];	// ���̺����� �������� ����
       //
       //void Start()
       //{
       //    // ���Ժ��� ����� �����Ͱ� �����ϴ��� �Ǵ�.
       //    for (int i = 0; i < 3; i++)
       //    {
       //        if (File.Exists(SaveManager_Json.instance.savePath + $"{i}"))    // �����Ͱ� �ִ� ���
       //        {
       //            savefile[i] = true;         // �ش� ���� ��ȣ�� bool�迭 true�� ��ȯ
       //            SaveManager_Json.instance.nowSlot = i;   // ������ ���� ��ȣ ����
       //            SaveManager_Json.instance.LoadData();    // �ش� ���� ������ �ҷ���
       //            slotText[i].text = SaveManager_Json.instance.nowPlayer.name; // ��ư�� �г��� ǥ��
       //        }
       //        else    // �����Ͱ� ���� ���
       //        {
       //            slotText[i].text = "�������";
       //        }
       //    }
       //    // �ҷ��� �����͸� �ʱ�ȭ��Ŵ.(��ư�� �г����� ǥ���ϱ������̾��� ����)
       //    SaveManager_Json.instance.DataClear();
       //}
       //
       //public void Slot(int number)    // ������ ��� ����
       //{
       //    SaveManager_Json.instance.nowSlot = number;  // ������ ��ȣ�� ���Թ�ȣ�� �Է���.
       //
       //    if (savefile[number])   // bool �迭���� ���� ���Թ�ȣ�� true��� = ������ �����Ѵٴ� ��
       //    {
       //        SaveManager_Json.instance.LoadData();    // �����͸� �ε��ϰ�
       //        LoadButton();   // ���Ӿ����� �̵�
       //    }
       //    else    // bool �迭���� ���� ���Թ�ȣ�� false��� �����Ͱ� ���ٴ� ��
       //    {
       //        Creat();    // �÷��̾� �г��� �Է� UI Ȱ��ȭ
       //    }
       //}
       //
       //public void Creat() // �÷��̾� �г��� �Է� UI�� Ȱ��ȭ�ϴ� �޼ҵ�
       //{
       //    creat.gameObject.SetActive(true);
       //}
       //
       //public void LoadButton()    // ���Ӿ����� �̵�
       //{
       //    if (!savefile[SaveManager_Json.instance.nowSlot])    // ���� ���Թ�ȣ�� �����Ͱ� ���ٸ�
       //    {
       //        SaveManager_Json.instance.nowPlayer.name = newPlayerName.text; // �Է��� �̸��� �����ؿ�
       //        SaveManager_Json.instance.SaveData(); // ���� ������ ������.
       //    }
       //    SaveManager_Json.instance.LoadData();
       //}
        
    }
}
