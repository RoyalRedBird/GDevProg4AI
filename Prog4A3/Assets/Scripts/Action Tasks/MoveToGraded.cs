using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToGraded : ActionTask<Transform> {

        [RequiredField]
        public BBParameter<GameObject> target;
        public BBParameter<float> speed = 2;
        public BBParameter<float> stopDistance = 0.1f;
        public bool waitActionFinish;

        protected override void OnExecute()
        {
            
            switch (agent.GetComponent<Blackboard>().GetVariableValue<string>("letterGrade"))
            {

                case "A":
                    agent.GetComponent<Blackboard>().SetVariableValue("speedModifier", .5f);
                    break;

                case "B":
                    agent.GetComponent<Blackboard>().SetVariableValue("speedModifier", .75f);
                    break;

                case "C":
                    agent.GetComponent<Blackboard>().SetVariableValue("speedModifier", 1f);
                    break;

                case "D":
                    agent.GetComponent<Blackboard>().SetVariableValue("speedModifier", 1.25f);
                    break;

                case "F":
                    agent.GetComponent<Blackboard>().SetVariableValue("speedModifier", 1.5f);
                    break;

            }

        }

        protected override void OnUpdate()
        {
            if ((agent.position - target.value.transform.position).magnitude <= stopDistance.value)
            {
                EndAction();
                return;
            }

            float speedMod = agent.GetComponent<Blackboard>().GetVariableValue<float>("speedModifier");

            agent.position = Vector3.MoveTowards(agent.position, target.value.transform.position, speed.value * speedMod * Time.deltaTime);
            if (!waitActionFinish)
            {
                EndAction();
            }
        }
    }
}