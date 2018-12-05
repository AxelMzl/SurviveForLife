using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sac", menuName = "Items", order = 1)]
public class Bag : Item, IUseable
{
    private int slots;

    [SerializeField]
    protected GameObject bagPrefab;

    public BagScript MyBagScript { get; set; }

    public int Slots
    {
        get
        {
            return slots;
        }
    }

    public Sprite MyIcon
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }

    /// <summary>
    /// Nombre d'emplacement dans un sac
    /// </summary>
    /// <param name="slots"></param>
    public void Initialize(int slots)
    {
        this.slots = slots;
    }
    
    /// <summary>
    ///  Equiper un sac
    /// </summary>
    public void Use()
    {
        if (InventoryScript.MyInstance.CanAddBag)
        {
            MyBagScript = Instantiate(bagPrefab, InventoryScript.MyInstance.transform).GetComponent<BagScript>();
            MyBagScript.AddSlots(slots);

            InventoryScript.MyInstance.AddBag(this);
        }
    }
}
 