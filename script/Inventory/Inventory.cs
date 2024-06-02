using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Timers;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


/// <summary>
/// it's stores item anfd mangeages curld and mangaes eppided ment logiic
/// <b>WE ARE NOT USING THIS FOR NOW!!!</b>
/// </summary>
    public class Inventory:MonoBehaviour
    {
        private ArrayList _inventory = new ArrayList();
        DataTable dt = new DataTable();
        

        private Dictionary<Item, int> ItemDictionary  = new Dictionary<Item, int>();
        public short maxCapacityOfUniqeItems_v = 99;
        public Transform holdSlot1;
        public Transform holdSlot2;


        public void Start()
        {
            dt.Columns.Add("Triggerable", typeof(ITriggerable));
            dt.Columns.Add("Meleeable", typeof(IMeleeable));


        }
        public short maxCapacityOfUniqeItems
        {
            set
            {
                maxCapacityOfUniqeItems_v = value;
                //Trim to size but drop instead of delete 
            }
            get
            {
                return maxCapacityOfUniqeItems_v;
            }
        }
        public short maxCapacityOfSameItemsInOneSlot_v = 99;
        public short maxCapacityOfSameItemsInOneSlot
        {
            set
            {
                maxCapacityOfSameItemsInOneSlot_v = value;
            }
            get
            {
                return maxCapacityOfSameItemsInOneSlot_v;
                
            }
        }

/// <summary>
/// add the item to _inventory arraylist and hads the item and item to a hashtable
/// </summary>
/// <param name="item"></param>
        public void Add(Item item)
        {
            //item.enabled = false;
            if (typeof(IGrabable).IsAssignableFrom(typeof(Item)))
            {
                _inventory.Add(item);
                ItemDictionary.Add(item,_inventory.Count-1);

            }
        }
        /// <summary>
        /// removes yhe item from excitace 
        /// </summary>
        /// <param name="index"></param>
        private void Remove(int index)
        {
            Remove(this.Get(index));
        }
        /// <summary>
        /// removes yhe item from excitace 
        /// </summary>
        /// <param name="index"></param>
        private void Remove(Item item)
        {
            //if (ItemDictionary.TryGetValue(item, out int theIndex))
            //{
           //     Remove(theIndex);
           // }
           _inventory.Remove(item);

        }

        /// <summary>
        /// get the item at index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Item at index else null if not there </returns>
        public Item Get(int index)
        {
            return (Item)_inventory[index];
          
        }
        
        /// <summary>
        /// get the 
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Item at index else null if not there </returns>
        private int GetPos(Item item)
        {
            return _inventory.IndexOf(item); 

        } 
     
     
        
        public void Drop(int index)
        {

            Item item = (Item)_inventory[index];
            // todo do something to item
            
        }
        public void MoveTo(Item item,int index)
        {

            MoveTo(item, this, index);

        }
        /// <summary>
        /// moves item to a inventory at the index
        /// </summary>
        /// <param name="item"></param>
        /// <param name="inventory"></param>
        /// <param name="index"></param>
        public void MoveTo(Item item,Inventory inventory, int index)
        {
            
            
        
        }
        /// <summary>
        /// moves item to a inventory
        /// </summary>
        /// <param name="item"></param>
        /// <param name="inventory"></param>
        public void MoveTo(Item item,Inventory inventory)
        {
            inventory.Add(item);
            
        
        }

        
    }
