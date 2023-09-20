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

        //bool jailInterlock;감옥연동 bool값
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
            return base.IsSelectableBy(interactor) && isControllable;//vr로 잡을수 있는가 없는가의 여부

        }

        public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)//vr이 그랩되었을 때 매순간 업데이트 되는 클래스
        {
            base.ProcessInteractable(updatePhase);

            if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
            {
                if (isSelected)//물체를 잡고있는동안(true)
                {
                    LeverUpdate();
                }
            }
        }

        private void LeverUpdate()
        {
            var direction=GetLookDirection();       //바라보는 방향
            var angle = Mathf.Atan2(direction.z, direction.y) * Mathf.Rad2Deg; //각도

            angle = Mathf.Clamp(angle, leverMin, leverMax);
            SetAngle(angle);
            
            if (Mathf.Approximately(angle,leverMax))//레버를 최대치로 옮길때 발동하는곳
            {
                leverMaxEvent.Invoke();
                //jailInterlock = true;//감옥연동true값
                isControllable = false;
                StartCoroutine(LeverEnable());
            }
        }


        Vector3 GetLookDirection()//레버가 바라보는 방향을 구하는 함수
        {
            Vector3 direction = interactor.GetAttachTransform(this).position - handle.position;
            direction = transform.InverseTransformDirection(direction);
            direction.x = 0;

            return direction.normalized;
        }

        private void SetAngle(float angle)//레버위치 지정함수
        {
            if(handle != null)
            {
                handle.localRotation = Quaternion.Euler(angle,0f, 0f);
            }
        }
        IEnumerator LeverEnable()//레버가 최대에 도달했을경우 최저값으로 돌아가는 코루틴
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
