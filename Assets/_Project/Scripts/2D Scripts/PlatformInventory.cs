using UnityEngine; 

public class PlatformInventory : MonoBehaviour
{
    [SerializeField] private bool isFull;
    public void AddItem(GameObject item)
    {
        if (!isFull)
        {
            isFull = true;
            item.transform.SetParent(transform);
            item.transform.localPosition = new Vector3(0,0,0);
            item.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f); 
        }
    }

    public int GetItem()
    {
        if (isFull)
        {
            int id = transform.GetChild(0).GetComponent<Keys>().keyId;
            return id;
        }
        return 0;
    }

    public void RemoveItem()
    {
        if (isFull)
        {
            isFull = false;
            Destroy(transform.GetChild(0).gameObject);
        }
    }

}
