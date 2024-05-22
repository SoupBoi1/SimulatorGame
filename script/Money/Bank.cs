using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Bank 
    {

        /// <summary>
        /// finite amount of money this world has
        /// </summary>
        /// <returns> </returns>
        public static float total_supply
        {
            get
            {
                return 21 * 10 ^ 6;
            }
        }

        public float value = 0;

        

       
    }
