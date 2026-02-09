using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ParticleTask : ActionTask {

        public BBParameter<ParticleSystem> waterSplashParticleBBP;

        public LayerMask groundMask;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {

            waterSplashParticleBBP.value = agent.GetComponentInChildren<ParticleSystem>();

            if (waterSplashParticleBBP.value == null)
                return $"{agent.name} - NavigationTask: Particle system not found.";
            else
                return null;

        }



        //Called once per frame while the action is active.
        protected override void OnUpdate() {
			
            CheckCurrentGroundTag();

		}

        private void CheckCurrentGroundTag()
        {
            RaycastHit hit;
            if (Physics.Raycast(agent.transform.position, agent.transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, groundMask))
            {

                GameObject hitObj = hit.collider.gameObject;

                if (hitObj.tag == "Water")
                {

                    Debug.Log("Swimming.");
                    waterSplashParticleBBP.value.Play();

                }
                else
                {

                    Debug.Log("Walking.");
                    waterSplashParticleBBP.value.Clear();
                    waterSplashParticleBBP.value.Pause();

                }

            }

        }

    }
}