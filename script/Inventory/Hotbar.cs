using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Timers;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
//TODO work on this at the movmemtn too lazy to work on this
/// <summary>
/// slots to hold the the itmes for a inventory whichn can eqquped when commaned  
/// </summary>
    public class Hotbar:MonoBehaviour
    {
        /// <summary>
        /// this hotbar can have only one inventory 
        /// </summary>
        //public Inventory _inventory;

        public int maxslotscount_value = 10;
        public Item[] items; 

        public int maxslotscount
        {
            set
            {
                maxslotscount_value = value;
                TrimHotBar(value);
            }
            get
            {
                return maxslotscount_value;
                
            }
        }

        
        /// <summary>
        /// which itme in the slop is currlly eppeed 
        /// </summary>
        public int cursor = 0;
        
        /// <summary>
        /// the point where the item can grip<br></br> mihght have morethrn one grippiint
        /// </summary>
        public Transform Gripoint1;
        public Transform Gripoint2;
        
        
        
        /// <summary>
        /// trims the items array to the size of tosize <br></br> it will trim to  it may remove elemts if the size is shorter the beofre else will add just more slots 
        /// </summary>
        /// <param name="tosize"> the size it eill trims array to  </param>
        public void TrimHotBar(int tosize)
        {
            TrimHotBar(tosize, items);
        }
        
        /// <summary>
        /// trims the items array to the size of tosize <br></br> it will trim to  it may remove elemts if the size is shorter the beofre else will add just more slots 
        /// </summary>
        /// <param name="tosize"> the size it eill trims array to  </param>
        /// <para name = "items"> the array it will trim</para>
        public void TrimHotBar(int tosize, Item[] items )
        {
            Item[] temItemList = new Item[tosize];
            for (int i = 0; i <= this.items.Length - 1 ; i++)
            {
                if (i < tosize - 1)
                {
                    //drop the items or put back in inventoery
                }
                else
                {
                    temItemList[i] = items[i];
                    
                    
                }
                
            }

            items = temItemList;
        }

        public void EquipItemOnCursor()
        {
            
        }
        
        
        

        

    }
