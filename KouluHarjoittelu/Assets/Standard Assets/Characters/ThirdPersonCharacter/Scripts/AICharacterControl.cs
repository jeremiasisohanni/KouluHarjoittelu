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
		private Vector3 currentPos;
		private bool sight = false;
		private float distance = 0.0f;


        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
			currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

	        agent.updateRotation = false;
	        agent.updatePosition = true;;
        }

	
		private void OnTriggerEnter (Collider other) {
			if(other.tag == "Player")
				sight = true;

		}

        // Update is called once per frame
        private void Update()
        {
			distance = Vector3.Distance(target.position, transform.position);
			print ("Distance: " + distance);

		if (target != null && sight == true)
            {
                agent.SetDestination(target.position);
                // use the values to move the character
                character.Move(agent.desiredVelocity, false, false);

            }
		else if (distance > 10) {
				sight = false;
				agent.SetDestination(currentPos);
				character.Move(agent.desiredVelocity,false, false);
			}
			else
			{
				// We still need to call the character's move function, but we send zeroed input as the move param.
				character.Move(Vector3.zero, false, false);
			}

        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
