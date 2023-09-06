using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Darik
{
    public class ElevatorController : MonoBehaviour
    {
        public enum State { Idle, Move, Open, Close, Wait }
        StateMachine<State, ElevatorController> stateMachine;

        [SerializeField] ElevatorInside elevator;
        [SerializeField] ElevatorOutside b1Outside;
        [SerializeField] ElevatorOutside b2Outside;
        public string state;

        public bool isCommanded = false;
        public int targetFloor = 0;
        private bool isMove = false;

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

        public void MoveCommand(int targetFloor)
        {
            if (targetFloor == -1)
            {
                if (elevator.CurFloor != -1)
                {
                    this.targetFloor = targetFloor;
                    isCommanded = true;
                }
                else
                {
                    // TODO : Button Return;
                }
            }
            if (targetFloor == -2)
            {
                if (elevator.CurFloor != -2)
                {
                    this.targetFloor = targetFloor;
                    isCommanded = true;
                }
                else
                {
                    // TODO : Button Return;
                }
            }
        }

        public void CallAtB1()
        {
            targetFloor = -1;
            isCommanded = true;
        }

        public void CallAtB2()
        {
            targetFloor = -2;
            isCommanded = true;
        }

        #region State
        private abstract class ElevatorControllerState : StateBase<State, ElevatorController>
        {
            protected GameObject gameObject => owner.gameObject;
            protected Transform transform => owner.transform;
            protected ElevatorInside elevator => owner.elevator;

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
                
            }

            public override void Enter()
            {
                owner.state = "Idle";
            }

            public override void Update()
            {

            }

            public override void Transition()
            {
                if (owner.isCommanded)
                {
                    stateMachine.ChangeState(State.Move);
                    owner.isCommanded = false;
                }
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
                owner.isMove = true;
                owner.state = "Move";
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
                owner.isMove = false;
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
                elevator.isClosed = true;
                owner.StartCoroutine(elevator.OpenCoroutine());
                if (elevator.CurFloor == -1)
                {
                    owner.b1Outside.isClosed = true;
                    owner.StartCoroutine(owner.b1Outside.OpenCoroutine());
                }
                else if (elevator.CurFloor == -2)
                {
                    owner.b2Outside.isClosed = true;
                    owner.StartCoroutine(owner.b2Outside.OpenCoroutine());
                }

                owner.state = "Open";
            }

            public override void Update()
            {

            }

            public override void Transition()
            {
                if (elevator.CurFloor == -1)
                {
                    if (!elevator.isClosed && !owner.b1Outside.isClosed)
                        stateMachine.ChangeState(State.Wait);
                }
                else if (elevator.CurFloor == -2)
                {
                    if (!elevator.isClosed && !owner.b2Outside.isClosed)
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
                elevator.isClosed = false;
                owner.StartCoroutine(elevator.CloseCoroutine());
                if (elevator.CurFloor == -1)
                {
                    owner.b1Outside.isClosed = false;
                    owner.StartCoroutine(owner.b1Outside.CloseCoroutine());
                }
                else if (elevator.CurFloor == -2)
                {
                    owner.b2Outside.isClosed = false;
                    owner.StartCoroutine(owner.b2Outside.CloseCoroutine());
                }

                owner.state = "Close";
            }

            public override void Update()
            {

            }

            public override void Transition()
            {
                if (elevator.CurFloor == -1)
                {
                    if (elevator.isClosed && owner.b1Outside.isClosed)
                        stateMachine.ChangeState(State.Idle);
                }
                else if (elevator.CurFloor == -2)
                {
                    if (elevator.isClosed && owner.b2Outside.isClosed)
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
                owner.state = "Wait";
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
