using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {
    private static InventoryScript instance;

    public static InventoryScript MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryScript>();
            }

            return instance;
        }
    }

    private List<Bag> bags = new List<Bag>();

    [SerializeField]
    private BagButton[] bagButtons;

    //POUR LES TESTS UNIQUEMENT
    [SerializeField]
    private Item[] items;

    public bool CanAddBag
    {
        get { return bags.Count < 1; }
    }

    private void Awake()
    {
        Bag bag = (Bag)Instantiate(items[0]);
        bag.Initialize(9);
        bag.Use();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Bag bag = (Bag)Instantiate(items[0]);
            bag.Initialize(9);
            bag.Use();
        }
    }

    public void AddBag(Bag bag)
    {
        foreach(BagButton bagButton in bagButtons)
        {
            if (bagButton.MyBag == null)
            {
                bagButton.MyBag = bag;
                bags.Add(bag);
                break;
            }
        }
    }

    public void OpenClose()
    {
        bool closedBag = bags.Find(x => !x.MyBagScript.IsOpen);

        // si closedBag == true alors ouvrir tout les sacs fermés 
        // si closedBag == false alors fermer tout les sacs ouvert 

        foreach (Bag bag in bags)
        {
            if(bag.MyBagScript.IsOpen != closedBag)
            {
                bag.MyBagScript.OpenClose();
            }
        }
    }
}
