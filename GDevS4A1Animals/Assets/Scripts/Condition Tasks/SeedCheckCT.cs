using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class SeedCheckCT : ConditionTask {

        public Blackboard duckBlackboard;
        public BBParameter<float> seedSearchRadiusBBP;
        public LayerMask seedMask;

        private Collider[] seedsFound;

        protected override string OnInit()
        {

            duckBlackboard = agent.GetComponent<Blackboard>();

            if(duckBlackboard == null )
            {

                return $"{agent.name} - SeedCheck: Blackboard not found.";

            }
            else
            {

                return null;

            }

            
        }

        //Called once per frame while the condition is active.
        //Return whether the condition is success or failure.
        protected override bool OnCheck() {

            seedsFound = Physics.OverlapSphere(agent.transform.position, seedSearchRadiusBBP.value, seedMask);

            GameObject closestSeedPile = null;
            float closestPileDistance = 9999;

            foreach(Collider seedCheck in seedsFound)
            {

                if(seedCheck.GetComponent<SeedPileScript>().GetPileOccupied()) {

                    Debug.Log($"{agent.name} - Found an occupied pile, ignoring.");
                    seedCheck.GetComponent<SeedPileScript>().MarkPileAsOccupied();
                    seedsFound = new Collider[0];

                }

            }

            if(seedsFound.Length > 0 )
            {

                foreach(Collider seed in seedsFound)
                {

                    if(Vector3.Distance(agent.transform.position, seed.transform.position) < closestPileDistance ) {

                        closestSeedPile = seed.gameObject;
                        closestPileDistance = Vector3.Distance(agent.transform.position, seed.transform.position);

                    }

                }

                Debug.Log("Seeds found!" + closestSeedPile.ToString() + " at " + closestSeedPile.transform.position);
                duckBlackboard.SetVariableValue("targetSeedPile", closestSeedPile);
                return true;

            }

			return false;
		}
	}
}