using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
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

            BoxCollider boxCollider =handle.GetComponentInChildren<BoxCollider>();
            SetAngle(angle);
            if(Mathf.Approximately(angle,leverMax))
            {
                leverMaxEvent.Invoke();
                StartCoroutine(LeverEnable(boxCollider));
            }
            else if(Mathf.Approximately(angle, leverMin))
            {
                leverMinEvent.Invoke();
                StartCoroutine(LeverEnable(boxCollider));
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
        IEnumerator LeverEnable(BoxCollider col)
        {
            col.enabled = false;
            yield return new WaitForSeconds(1);
            col.enabled = true;
        }
    }

}