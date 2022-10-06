[System.Serializable]
public class SimpleInventory<T>
{
    public UnityDictionary<T, int> inventory;

    //-----------Item Management---------------
    public bool UseItem(T item, int count = 1)
    {
        if (inventory.dict.ContainsKey(item)) {
            if (inventory.dict[item] >= count) {
                inventory.dict[item] -= count;
                RemoveItemTypeCheck(item);
                return true;
            }
            else { return false; } //not enough items of requested type
        }
        else { return false; }
    }

    public void GainItem(T item, int count  = 1)
    {
        if (inventory.dict.ContainsKey(item)) {
            inventory.dict[item] += count;
        }
        else { inventory.dict.Add(item, count); }
    }

    //----------------remove item types--------------
    private void RemoveItemTypeCheck(T item)
    {
        if (inventory.dict[item] <= 0) {
            inventory.dict.Remove(item);
        }
    }
}
