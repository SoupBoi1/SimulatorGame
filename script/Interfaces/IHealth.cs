
    public interface IHealth
    {
        
        /// <summary>
        /// checks if confitions for dead and triger is revive or is death denpending 
        /// </summary>
        /// <returns></returns>
        public bool isDeath();

        /// <summary>
        /// trigger when Max healt id changed 
        /// </summary>
        public void OnMaxHealtSet();

        /// <summary>
        ///       adds h number of health 
        /// </summary>
        /// <param name="h"> the number of health add tto the obj</param>

        public void Heal(float h);

        /// <summary>
        ///  Damage by <paramref name="damage"/> of flaot <b>health</b> of object <c>Health</c>
        /// 
        /// </summary>
        /// <example>
        /// </example>
        /// <param name="damage"></param>
        public  void Damage(float damage);


    }
