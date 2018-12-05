using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour {

    /// <summary>
    /// Prefab pour crée l'emplacement
    /// </summary>
    /// <param name="slotCount">Nombre d'emplacement a créer</param>
    [SerializeField]
    private GameObject slotPrefab;

    private CanvasGroup canvasGroup;

    public bool IsOpen
    {
        get
        {
            return canvasGroup.alpha > 0;
        }
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// Crée des emplacements pour le sac
    /// </summary>
    /// <param name="slotCount">Nombre d'emplacement a créer</param>
    public void AddSlots(int slotCount)
    {
        for(int i = 0; i < slotCount; i++)
        {
            Instantiate(slotPrefab, transform);
        }
    }

    public void OpenClose()
    {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;

        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
    }
}
