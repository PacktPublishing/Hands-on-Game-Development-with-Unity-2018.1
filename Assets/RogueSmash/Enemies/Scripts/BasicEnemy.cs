using System.Collections.Generic;
using MyCompany.GameFramework.EnemyAI;
using MyCompany.GameFramework.EnemyAI.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace MyCompany.RogueSmash.Enemies
{
    public class BasicEnemy : MonoBehaviour
    {
        protected IMovementBehavior movementBehavior;

        protected Dictionary<IActionCondition, IEnemyAbility> abilities =
            new Dictionary<IActionCondition, IEnemyAbility>();
        
        protected NavMeshAgent agent;

        protected GameObject player;

        private void Awake()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            player = GameObject.FindWithTag("Player");
            
            /* Initializing interfaces */
            movementBehavior = new RoamBehavior(agent, 5);
            AddDashAbility();
        }

        private void Update()
        {
            if (!agent.hasPath)
            {
                movementBehavior.SetNextTargetPosition();
            }

            CheckConditions();
        }
        
        private void AddDashAbility()
        {
            DashAbility ability = new DashAbility(gameObject, player.transform);
            ability.onBegin += () => { agent.isStopped = true;};
            ability.onComplete += () => { agent.isStopped = false;};
            abilities.Add(new RangeCondition(transform, player.transform, 7.0f), ability);
        }

        private void CheckConditions()
        {
            foreach (var kvp in abilities)
            {
                if (kvp.Key.CheckCondition())
                {
                    kvp.Value.UseAbility();
                }
            }
        }
    }
}
