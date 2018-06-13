using MyCompany.GameFramework.EnemyAI.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace MyCompany.GameFramework.EnemyAI
{
    public class RoamBehavior : IMovementBehavior
    {
        protected NavMeshAgent agent;
        protected Vector3 targetPosition;
        protected float roamingRange;

        public RoamBehavior(NavMeshAgent agent, float roamingRange)
        {
            this.agent = agent;
            this.roamingRange = roamingRange;
        }

        public void SetNextTargetPosition()
        {
            targetPosition = agent.transform.position + new Vector3(Random.Range(-roamingRange, roamingRange), 0,
                                 Random.Range(-roamingRange, roamingRange));
            agent.SetDestination(targetPosition);
        }
    }
}