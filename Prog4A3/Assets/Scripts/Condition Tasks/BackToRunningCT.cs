using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class BackToRunningCT : ConditionTask {

		public BBParameter<float> breakTimeBB;
		public BBParameter<float> timeToBreakBB;

		public Color normalColor;
        public Material blockMat;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			blockMat = agent.GetComponent<MeshRenderer>().material;
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			if(breakTimeBB.value <= 0)
			{

				Debug.Log("Back to running!");
				blockMat.color = normalColor;
				return true;

			}
			else
			{

				return false;

			}

		}

	}

}