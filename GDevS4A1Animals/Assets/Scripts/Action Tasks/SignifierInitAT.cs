using NodeCanvas.Framework;
using UnityEngine;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class SignifierInitAT : ActionTask {

		public Blackboard duckBB;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {

			duckBB = agent.GetComponent<Blackboard>();

			if(duckBB == null)
			{

				return $"Blackboard not found on {agent.name}";

			}

			GameObject qMark = agent.transform.GetChild(0).gameObject;
			GameObject eMark = agent.transform.GetChild(1).gameObject;

			Debug.Log(agent.transform.childCount);

			if(qMark == null)
			{
				Debug.Log("Question Mark not found.");
			}

            if (eMark == null)
            {
                Debug.Log("Exclaimation Mark not found.");
            }

            duckBB.SetVariableValue("questionMark", qMark);
            duckBB.SetVariableValue("exclaimationMark", eMark);

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			EndAction(true);
		}

	}

}