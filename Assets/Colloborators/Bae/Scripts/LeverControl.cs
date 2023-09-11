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
        float getBackCount=2;
        [SerializeField]
        float leverMax=90f;
        [SerializeField]
        float leverMin=-90f;

        float timer = 0;
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
            
            if (Mathf.Approximately(angle,leverMax))
            {
                leverMaxEvent.Invoke();
                isControllable = false;
                StartCoroutine(LeverEnable());
            }
        }


        Vector3 GetLookDirection()
        {
            Vector3 direction = interactor.GetAttachTransform(this).position - handle.position;
            direction = transform.InverseTransformDirection(direction);
            direction.x = 0;

            return direction.normalized;
        }

        private void SetAngle(float angle)
        {
            if(handle != null)
            {
                handle.localRotation = Quaternion.Euler(angle,0f, 0f);
            }
        }
        IEnumerator LeverEnable()
        {
            float defaultAngle;
            float maxTimer = 1.5f;
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
