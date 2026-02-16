using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class ChickInitAT : ActionTask {

		public BBParameter<float> chickInitRadiusBBP;
		public BBParameter<List<GameObject>> chicksListBBP;
		public LayerMask chickMask;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			List<GameObject> chickListTemp = new List<GameObject>();

			Collider[] chicksFound = Physics.OverlapSphere(agent.transform.position, chickInitRadiusBBP.value, chickMask);

			foreach(Collider chick in chicksFound)
			{

				Debug.Log("Found a birb.");

				Blackboard chickBB = chick.GetComponent<Blackboard>();

				if(chickBB.GetVariable<GameObject>("motherDuck") != null)
				{

                    chickBB.SetVariableValue("motherDuck", agent.gameObject);
                    chickListTemp.Add(chick.gameObject);

                }				

			}

			chicksListBBP.value = chickListTemp;

			EndAction(true);
		}

	}

}