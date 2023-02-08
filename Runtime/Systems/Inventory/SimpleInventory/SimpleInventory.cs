namespace DevKit {
    [System.Serializable]
    public class SimpleInventory<T>
    {
        public UnityDictionary<T, int> inventory;

        //-----------Item Management---------------
        public bool UseItem(T item, int count = 1)
        {
            if (inventory.ContainsKey(item)) {
                if (inventory[item] >= count) {
                    inventory[item] -= count;
                    RemoveItemTypeCheck(item);
                    return true;
                }
                else { return false; } //not enough items of requested type
            }
            else { return false; }
        }

        public void GainItem(T item, int count  = 1)
        {
            if (inventory.ContainsKey(item)) {
                inventory[item] += count;
            }
            else { inventory.Add(item, count); }
        }

        //----------------remove item types--------------
        private void RemoveItemTypeCheck(T item)
        {
            if (inventory[item] <= 0) {
                inventory.Remove(item);
            }
        }
    }
}
