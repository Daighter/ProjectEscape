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
        public GameObject creat;    // �÷��̾� �г��� �Է�UI
        public TMP_Text[] slotText;     // ���Թ�ư �Ʒ��� �����ϴ� Text��
        public TMP_Text newPlayerName;	// ���� �Էµ� �÷��̾��� �г���

        bool[] savefile = new bool[3];	// ���̺����� �������� ����

        void Start()
        {
            // ���Ժ��� ����� �����Ͱ� �����ϴ��� �Ǵ�.
            for (int i = 0; i < 3; i++)
            {
                if (File.Exists(SaveManager.instance.savePath + $"{i}"))    // �����Ͱ� �ִ� ���
                {
                    savefile[i] = true;         // �ش� ���� ��ȣ�� bool�迭 true�� ��ȯ
                    SaveManager.instance.nowSlot = i;   // ������ ���� ��ȣ ����
                    SaveManager.instance.LoadData();    // �ش� ���� ������ �ҷ���
                    slotText[i].text = SaveManager.instance.nowPlayer.name; // ��ư�� �г��� ǥ��
                }
                else    // �����Ͱ� ���� ���
                {
                    slotText[i].text = "�������";
                }
            }
            // �ҷ��� �����͸� �ʱ�ȭ��Ŵ.(��ư�� �г����� ǥ���ϱ������̾��� ����)
            SaveManager.instance.DataClear();
        }

        public void Slot(int number)    // ������ ��� ����
        {
            SaveManager.instance.nowSlot = number;  // ������ ��ȣ�� ���Թ�ȣ�� �Է���.

            if (savefile[number])   // bool �迭���� ���� ���Թ�ȣ�� true��� = ������ �����Ѵٴ� ��
            {
                SaveManager.instance.LoadData();    // �����͸� �ε��ϰ�
                LoadButton();   // ���Ӿ����� �̵�
            }
            else    // bool �迭���� ���� ���Թ�ȣ�� false��� �����Ͱ� ���ٴ� ��
            {
                Creat();    // �÷��̾� �г��� �Է� UI Ȱ��ȭ
            }
        }

        public void Creat() // �÷��̾� �г��� �Է� UI�� Ȱ��ȭ�ϴ� �޼ҵ�
        {
            creat.gameObject.SetActive(true);
        }

        public void LoadButton()    // ���Ӿ����� �̵�
        {
            if (!savefile[SaveManager.instance.nowSlot])    // ���� ���Թ�ȣ�� �����Ͱ� ���ٸ�
            {
                SaveManager.instance.nowPlayer.name = newPlayerName.text; // �Է��� �̸��� �����ؿ�
                SaveManager.instance.SaveData(); // ���� ������ ������.
            }
            SaveManager.instance.LoadData();
        }
        
    }
}
