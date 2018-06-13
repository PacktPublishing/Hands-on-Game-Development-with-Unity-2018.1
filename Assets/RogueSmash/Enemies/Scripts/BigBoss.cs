using System.Collections.Generic;
using MyCompany.GameFramework.EnemyAI;
using MyCompany.GameFramework.EnemyAI.Interfaces;
using MyCompany.GameFramework.Physics.Interfaces;
using MyCompany.GameFramework.ResourceSystem;
using MyCompany.GameFramework.ResourceSystem.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace MyCompany.RogueSmash.Enemies
{
    public class BigBoss : MonoBehaviour, IDamageable
    {
        protected IResource health;
        protected IMovementBehavior movementBehavior;
        protected Dictionary<IActionCondition, IEnemyAbility> abilities =
            new Dictionary<IActionCondition, IEnemyAbility>();
        
        protected NavMeshAgent agent;
        protected GameObject player;
        [SerializeField] protected GameObject projectilePrefab;

        public IResource Health
        {
            get { return health; }
        }

        private void Awake()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            player = GameObject.FindWithTag("Player");
            health = new Health(10);
            
            /* Initializing interfaces */
            movementBehavior = new RoamBehavior(agent, 8);
            SetupAbilities();
        }

        private void SetupAbilities()
        {
            BurstAttack ba = new BurstAttack(4, transform, projectilePrefab);
            ba.onBegin+= () => { agent.isStopped = true;};
            ba.onComplete += () => { agent.isStopped = false;};
            RangeCondition rc = new RangeCondition(transform, player.transform, 12);
            abilities.Add(rc, ba);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            ICollisionEnterHandler[] handlers =
                collision.gameObject.GetComponents<ICollisionEnterHandler>();
            if (handlers != null)
            {
                foreach (var handler in handlers)
                {
                    handler.Handle(this.gameObject, collision);
                }
            }
        }
        
        private void Update()
        {
            if (!agent.hasPath)
            {
                movementBehavior.SetNextTargetPosition();
            }

            CheckConditions();
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

        public void Damage(float amount)
        {
            health.Remove(amount);
        }
    }
}
