
    public struct Money
    {
        private readonly float _value;

        private static ulong total_supply_value = 21*10^7 ;

        public static ulong total_supply
        {
            get
            {
                return total_supply_value;
            } 
        }

        public void SetWorldTotal_Supply(ulong totalSupplyValue)
        {
            total_supply_value = totalSupplyValue;
        }

        public Money(float value)
        {
            _value = value;
        }
        
        // Example of one member of double:
        public static Money operator *(Money d1, Money d2) 
        {
            return new Money(d1._value * d2._value);
        }
        
        /// <summary>
        /// Implicit conversion from float to Money. 
        /// Implicit: No cast operator is required.
        /// </summary>
        public static implicit operator Money(float value)
        {
            return new Money(value);
        }

        /// <summary>
        /// Explicit conversion from Money to float. 
        /// Explicit: A cast operator is required.
        /// </summary>
        public static explicit operator double(Money value)
        {
            return value._value;
        }

        /// <summary>
        /// Explicit conversion from nt to Money. 
        /// Explicit: A cast operator is required.
        /// </summary>
        public static explicit operator Money(int value)
        {
            return new Money(value);
        }

        /// <summary>
        /// Explicit conversion from MoneyAmount to int. 
        /// Explicit: A cast operator is required.
        /// </summary>
        public static explicit operator int(Money value)
        {
            return (int)value._value;
        }
        


    }
