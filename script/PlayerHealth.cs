using System;

namespace script
{
    public class PlayerHealth:Health
    {
        private bool Ragdoll;

        public PlayerController _PlayerController;

        private void Start()
        {
            _PlayerController = GetComponent<PlayerController>();
        }

        /// <summary>
        /// will menable the ondeath of player controller
        /// </summary>
        public override void OnDeath()
        {
            base.OnDeath();
            _PlayerController.OnDeath();
        }
        
        /// <summary>
        /// trigers the conditions for onRvive
        /// </summary>
        public override void OnRevive()
        {
            base.OnRevive();
            _PlayerController.DoRagdoll();
        }
    }
}