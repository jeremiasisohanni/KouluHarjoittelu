using System;
using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof (NavMeshAgent))]
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class wanderingAI : MonoBehaviour
	{
		public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
		public ThirdPersonCharacter character { get; private set; } // the character we are controlling
		public Transform target; // target to aim for

		public Transform[] targetit;
		public int timeWait = 5000;

		private float distance = 0.0f;
		public float turnSpeedInMelee = 10.0f;

		public int x;
		
		
		// Use this for initialization
		private void Start()
		{
			// get the components on the object we need ( should not be null due to require component so no need to check )
			agent = GetComponentInChildren<NavMeshAgent>();
			character = GetComponent<ThirdPersonCharacter>();
			
			agent.updateRotation = false;
			agent.updatePosition = true;
		}
		
		// Update is called once per frame
		private void Update()
		{

			
			if (target != null)
			{	
				agent.SetDestination(target.position);
				// use the values to move the character
				character.Move(agent.desiredVelocity, false, false);
				checkOnArrive();
				
			}
			else
			{
				// We still need to call the character's move function, but we send zeroed input as the move param.
				character.Move(Vector3.zero, false, false);
			}
			
		}

		private void checkOnArrive() {
			distance = Vector3.Distance(target.position, transform.position);

			if (distance <= 1) {
				wait ();
				x = UnityEngine.Random.Range(0,5);
				target = targetit[x];
			}
		}

		IEnumerator wait() {
			yield return new WaitForSeconds(timeWait);
		}
	}
}
