namespace script
{
    public class PlayerHealth:Health
    {
        private bool Ragdoll;
        //TODO rangdoll and more features
        public override void OnDeath()
        {
            base.OnDeath();
            Ragdoll = true;
        }
    }
}