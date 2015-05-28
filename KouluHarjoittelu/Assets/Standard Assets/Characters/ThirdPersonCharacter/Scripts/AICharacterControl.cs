using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target; // target to aim for
		public Transform targetPlayer;
		private bool sight = false;
		private float distance = 0.0f;
		private float distance2 = 0.0f;
		public float turnSpeedInMelee = 10.0f;


        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }

	
		private void OnTriggerEnter (Collider other) {
			if (other.tag == "Player")
				sight = true;

		}

        // Update is called once per frame
        private void Update()
        {

		if (target != null && sight == false)
            {
                agent.SetDestination(target.position);
                // use the values to move the character
                character.Move(agent.desiredVelocity, false, false);

            }
		else if (targetPlayer != null && sight == true) {
				agent.SetDestination(targetPlayer.position);
				character.Move(agent.desiredVelocity,false, false);
				checkDistanceToPlayer();
			}
			else
			{
				// We still need to call the character's move function, but we send zeroed input as the move param.
				character.Move(Vector3.zero, false, false);
			}

        }

		private void checkDistanceToPlayer() {
			distance = Vector3.Distance(target.position, transform.position);
			distance2 = Vector3.Distance(targetPlayer.position, transform.position);

			print (distance);
			if (distance >= 80)
				sight = false;
			if (distance2 < 5) {
				Vector3 direction = (targetPlayer.position - transform.position).normalized;
				Quaternion look = Quaternion.LookRotation(direction);
				transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * turnSpeedInMelee);
			}
		}

    }
}
