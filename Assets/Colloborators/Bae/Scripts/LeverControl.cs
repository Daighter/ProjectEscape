using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

namespace Bae
{
    public class LeverControl : XRBaseInteractable
    {
        

        [SerializeField]
        UnityEvent leverMaxEvent;
        [SerializeField]
        UnityEvent leverMinEvent;
        [SerializeField]
        Transform handle;
        
        [SerializeField]
        float leverMax=90f;
        [SerializeField]
        float leverMin=-90f;
        float timer = 0;

        //bool jailInterlock;�������� bool��
        bool isControllable=true;
        IXRSelectInteractor interactor; 

        protected override void OnEnable()
        {
            base.OnEnable();
            selectEntered.AddListener(HoldGrab);
            selectExited.AddListener(ReleaseGrab);
            SetAngle(leverMin);
        }
        protected override void OnDisable()
        {
            selectEntered.RemoveListener(HoldGrab);
            selectExited.RemoveListener(ReleaseGrab);
            base.OnDisable();   
        }

        private void HoldGrab(SelectEnterEventArgs args)
        {
            interactor = args.interactorObject;
        }

        private void ReleaseGrab(SelectExitEventArgs args)
        {
            interactor = null;
        }

        public override bool IsSelectableBy(IXRSelectInteractor interactor)
        {
            return base.IsSelectableBy(interactor) && isControllable;//vr�� ������ �ִ°� ���°��� ����

        }

        public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)//vr�� �׷��Ǿ��� �� �ż��� ������Ʈ �Ǵ� Ŭ����
        {
            base.ProcessInteractable(updatePhase);

            if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
            {
                if (isSelected)//��ü�� ����ִµ���(true)
                {
                    LeverUpdate();
                }
            }
        }

        private void LeverUpdate()
        {
            var direction=GetLookDirection();       //�ٶ󺸴� ����
            var angle = Mathf.Atan2(direction.z, direction.y) * Mathf.Rad2Deg; //����

            angle = Mathf.Clamp(angle, leverMin, leverMax);
            SetAngle(angle);
            
            if (Mathf.Approximately(angle,leverMax))//������ �ִ�ġ�� �ű涧 �ߵ��ϴ°�
            {
                leverMaxEvent.Invoke();
                //jailInterlock = true;//��������true��
                isControllable = false;
                StartCoroutine(LeverEnable());
            }
        }


        Vector3 GetLookDirection()//������ �ٶ󺸴� ������ ���ϴ� �Լ�
        {
            Vector3 direction = interactor.GetAttachTransform(this).position - handle.position;
            direction = transform.InverseTransformDirection(direction);
            direction.x = 0;

            return direction.normalized;
        }

        private void SetAngle(float angle)//������ġ �����Լ�
        {
            if(handle != null)
            {
                handle.localRotation = Quaternion.Euler(angle,0f, 0f);
            }
        }
        IEnumerator LeverEnable()//������ �ִ뿡 ����������� ���������� ���ư��� �ڷ�ƾ
        {
            float defaultAngle;
            float maxTimer = 4f;
            while(timer< maxTimer)
            {
                defaultAngle = Mathf.Lerp(leverMax, leverMin, timer / maxTimer);
                timer += Time.deltaTime;
                SetAngle(defaultAngle);
                yield return null;
                
            }                

            SetAngle(leverMin);
            leverMinEvent.Invoke();
            isControllable = true;
            timer = 0;
            
        }
    }

}
