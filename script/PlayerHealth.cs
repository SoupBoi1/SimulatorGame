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

        //TODO rangdoll and more features
        public override void OnDeath()
        {
            base.OnDeath();
            _PlayerController.DoRagdoll();
        }
        public override void OnRevive()
        {
            base.OnRevive();
            _PlayerController.DoRagdoll();
        }
    }
}