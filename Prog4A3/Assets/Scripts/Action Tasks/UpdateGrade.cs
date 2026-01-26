using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class UpdateGrade : ActionTask {

		public BBParameter<GameObject> followBox;
		public Blackboard myBlackboard;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {

			myBlackboard = agent.GetComponent<Blackboard>();

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            Blackboard cubeBoard = followBox.value.GetComponent<Blackboard>();
            float finalLapTime = myBlackboard.GetVariableValue<float>("lapTime");

			if(finalLapTime < 3f)
			{

				cubeBoard.SetVariableValue("letterGrade", "A");

			}else if (finalLapTime < 5) {

                cubeBoard.SetVariableValue("letterGrade", "B");

            }
            else if (finalLapTime < 7)
			{

                cubeBoard.SetVariableValue("letterGrade", "C");

            }
            else if (finalLapTime < 9)
			{

                cubeBoard.SetVariableValue("letterGrade", "D");

            } else
			{

                cubeBoard.SetVariableValue("letterGrade", "F");

            }

			myBlackboard.SetVariableValue("lapTime", 0f);
			cubeBoard.SetVariableValue("waypointsHit", 0);
            EndAction(true);

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}