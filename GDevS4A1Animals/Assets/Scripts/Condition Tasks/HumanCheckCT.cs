using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class HumanCheckCT : ConditionTask {

        public BBParameter<GameObject> humanFleePosBBP;
        public BBParameter<float> humanFleeRadiusBBP;
        public LayerMask humanLayer;

        //Called once per frame while the condition is active.
        //Return whether the condition is success or failure.
        protected override bool OnCheck() {

            Collider[] humansFound = Physics.OverlapSphere(agent.transform.position, humanFleeRadiusBBP.value, humanLayer);

            if (humansFound.Length > 0)
            { 
                
                humanFleePosBBP.value = humansFound[0].gameObject;
                return true;

            }

            return false;

		}
	}
}