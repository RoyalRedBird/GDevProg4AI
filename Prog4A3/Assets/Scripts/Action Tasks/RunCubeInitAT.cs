using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RunCubeInitAT : ActionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {

			Blackboard myBlackboard = agent.gameObject.GetComponent<Blackboard>();
			myBlackboard.SetVariableValue("waypointSphere", GameObject.Find("WPSphere"));
			myBlackboard.SetVariableValue("myTransform", agent.transform);

			if (myBlackboard.GetVariable<GameObject>("waypointSphere") == null)
				return "Where is the sphere?";

            if (myBlackboard.GetVariable<GameObject>("myTransform") == null)
                return "Where is myself?";

            return null;
		}

	}

}