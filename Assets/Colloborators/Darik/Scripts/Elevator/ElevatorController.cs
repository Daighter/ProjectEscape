using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ElevatorController : MonoBehaviour
    {
        public enum State { Idle, Move, Open, Close, Wait }
        StateMachine<State, ElevatorController> stateMachine;

        [SerializeField] ElevatorInsideDoor elevator;
        [SerializeField] ElevatorOutsideDoor b1OutsideDoor;
        [SerializeField] ElevatorOutsideDoor b2OutsideDoor;

        private bool isCommanded = false;
        private int targetFloor = 0;

        protected void Awake()
        {
            stateMachine = new StateMachine<State, ElevatorController>(this);
            stateMachine.AddState(State.Idle, new IdleState(this, stateMachine));
            stateMachine.AddState(State.Move, new MoveState(this, stateMachine));
            stateMachine.AddState(State.Open, new OpenState(this, stateMachine));
            stateMachine.AddState(State.Close, new CloseState(this, stateMachine));
            stateMachine.AddState(State.Wait, new WaitState(this, stateMachine));
        }

        private void Start()
        {
            targetFloor = 0;
            stateMachine.SetUp(State.Idle);
        }

        private void Update()
        {
            stateMachine.Update();
        }

        public void Command(int targetFloor)
        {
            if (targetFloor == -1 || targetFloor == -2)
            {
                isCommanded = true;
                this.targetFloor = targetFloor;
            }
        }

        #region State
        private abstract class ElevatorControllerState : StateBase<State, ElevatorController>
        {
            protected GameObject gameObject => owner.gameObject;
            protected Transform transform => owner.transform;
            protected ElevatorInsideDoor elevator => owner.elevator;

            protected ElevatorControllerState(ElevatorController owner, StateMachine<State, ElevatorController> stateMachine) : base(owner, stateMachine)
            {
            }
        }

        private class IdleState : ElevatorControllerState
        {
            public IdleState(ElevatorController owner, StateMachine<State, ElevatorController> stateMachine) : base(owner, stateMachine)
            {
            }

            public override void Setup()
            {
                elevator.transform.position = new Vector3(elevator.transform.position.x, -3, elevator.transform.position.z);
            }

            public override void Enter()
            {

            }

            public override void Update()
            {

            }

            public override void Transition()
            {
                if (owner.isCommanded)
                    stateMachine.ChangeState(State.Move);
                owner.isCommanded = false;
            }

            public override void Exit()
            {

            }
        }

        private class MoveToB1State : ElevatorControllerState
        {
            public MoveToB1State(ElevatorController owner, StateMachine<State, ElevatorController> stateMachine) : base(owner, stateMachine)
            {
            }

            public override void Setup()
            {

            }

            public override void Enter()
            {
                elevator.isAlived = false;
            }

            public override void Update()
            {
                elevator.Move(owner.targetFloor);
            }

            public override void Transition()
            {
                if (elevator.isAlived)
                    stateMachine.ChangeState(State.Open);
            }

            public override void Exit()
            {

            }
        }

        private class MoveState : ElevatorControllerState
        {
            public MoveState(ElevatorController owner, StateMachine<State, ElevatorController> stateMachine) : base(owner, stateMachine)
            {
            }

            public override void Setup()
            {

            }

            public override void Enter()
            {
                elevator.isAlived = false;
            }

            public override void Update()
            {

            }

            public override void Transition()
            {

            }

            public override void Exit()
            {

            }
        }

        private class OpenState : ElevatorControllerState
        {
            public OpenState(ElevatorController owner, StateMachine<State, ElevatorController> stateMachine) : base(owner, stateMachine)
            {
            }

            public override void Setup()
            {

            }

            public override void Enter()
            {
                owner.StartCoroutine(elevator.OpenCoroutine());
                if (elevator.CurFloor == -1)
                    owner.StartCoroutine(owner.b1OutsideDoor.OpenCoroutine());
                else if (elevator.CurFloor == -2)
                    owner.StartCoroutine(owner.b2OutsideDoor.OpenCoroutine());
            }

            public override void Update()
            {

            }

            public override void Transition()
            {
                if (elevator.CurFloor == -1)
                {
                    if (!elevator.IsClosed && !owner.b1OutsideDoor.IsClosed)
                        stateMachine.ChangeState(State.Wait);
                }
                else if (elevator.CurFloor == -2)
                {
                    if (!elevator.IsClosed && !owner.b2OutsideDoor.IsClosed)
                        stateMachine.ChangeState(State.Wait);
                }
            }

            public override void Exit()
            {

            }
        }

        private class CloseState : ElevatorControllerState
        {
            public CloseState(ElevatorController owner, StateMachine<State, ElevatorController> stateMachine) : base(owner, stateMachine)
            {
            }

            public override void Setup()
            {

            }

            public override void Enter()
            {
                owner.StartCoroutine(elevator.CloseCoroutine());
                if (elevator.CurFloor == -1)
                    owner.StartCoroutine(owner.b1OutsideDoor.CloseCoroutine());
                else if (elevator.CurFloor == -2)
                    owner.StartCoroutine(owner.b2OutsideDoor.CloseCoroutine());
            }

            public override void Update()
            {
                
            }

            public override void Transition()
            {
                if (elevator.CurFloor == -1)
                {
                    if (elevator.IsClosed && owner.b1OutsideDoor.IsClosed)
                        stateMachine.ChangeState(State.Idle);
                }
                else if (elevator.CurFloor == -2)
                {
                    if (elevator.IsClosed && owner.b2OutsideDoor.IsClosed)
                        stateMachine.ChangeState(State.Idle);
                }
            }

            public override void Exit()
            {

            }
        }

        private class WaitState : ElevatorControllerState
        {
            private float curTime;

            public WaitState(ElevatorController owner, StateMachine<State, ElevatorController> stateMachine) : base(owner, stateMachine)
            {
            }

            public override void Setup()
            {

            }

            public override void Enter()
            {
                curTime = 0f;
            }

            public override void Update()
            {
                curTime += Time.deltaTime;
            }

            public override void Transition()
            {
                if (curTime >= 3f)
                    stateMachine.ChangeState(State.Close);
            }

            public override void Exit()
            {

            }
        }
        #endregion
    }
}
