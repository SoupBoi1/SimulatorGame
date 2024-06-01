using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Timers;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


/// <summary>
/// it's stores item anfd mangeages curld and mangaes eppided ment logiic
/// </summary>
    public class Inventory:MonoBehaviour
    {
        private ArrayList _inventory = new ArrayList();
        DataTable dt = new DataTable();
        

        private Dictionary<Item, int> d = new Dictionary<Item, int>();
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


        public void Add(Item item)
        {
            //item.enabled = false;
            if (typeof(IGrabable).IsAssignableFrom(typeof(Item)))
            {
                _inventory.Add(item);
                d.Add(item,_inventory.Count-1);

            }
        }
        
        public void Drop(int index)
        {

            Item item = (Item)_inventory[index];
            // todo do something to item
            
        }
        
        public void PutInInventory(Item item)
        {
            
            
        
        }

        
    }
