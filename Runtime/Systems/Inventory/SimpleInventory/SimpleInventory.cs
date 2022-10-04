using System.Collections.Generic;

[System.Serializable]
public class SimpleInventory<T>
{
    [System.Serializable]
    public class ItemStack {
        public T item;
        public int count;
    }

    public List<ItemStack> inventory = new List<ItemStack>();

    //-----------item management-----------
    public bool UseItem(T item, int count = 1)
    {
        for (int i = 0; i < inventory.Count; i++) {
            if (item.Equals(inventory[i].item)) {
                if (inventory[i].count >= count) {
                    inventory[i].count -= count;
                    if (inventory[i].count <= 0) { RemoveItemType(i); }
                    return true;
                }
                else return false; //not enough items of requested type
            }
        }
        return false; //item not in inventory
    }

    private void RemoveItemType(int index)
    {
        inventory.RemoveAt(index);
    }

    public void GainItem(T item, int count = 1)
    {
        for (int i = 0; i < inventory.Count; i++) {
            if (item.Equals(inventory[i].item)) {
                inventory[i].count += count;
                return;
            }
        }
        //add new item type to inventory
        inventory.Add(new ItemStack { item = item, count = count });
    }
}
