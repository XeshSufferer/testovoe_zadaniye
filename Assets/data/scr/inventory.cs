using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int[] _inventory;
    [SerializeField] private int _selectedInvCell = 1;
    [SerializeField] private int SavedI_GetNullCell;

    [SerializeField] private Image[] _ItemsIMG;

    [SerializeField] private Sprite[] _itemsSprite;

    /*
    ИДшники предметов
    0 - Пустота
    1 - капкан 
    */
    private void Start()
    {
        GetNullCell();
        Debug.Log(SavedI_GetNullCell);
        //CheckingItemsInUI();
        
    }
    public void SetItem(int NumInvCell, int ItemID)
    {
        _inventory[NumInvCell] = ItemID;
    }
    public void GetNullCell()
    {
        for(int i = 0; i < _inventory.Length; i++)
        {
            Debug.Log("CellID = " + i + ", ItemID = " + _inventory[i]);
            if(_inventory[i] == 0)
            {
                SavedI_GetNullCell = i;
            }
            
        }
    }
    private void Update()
    {
        CheckingItemsInUI();
    }
    
    private void CheckingItemsInUI()
    {
        Debug.Log("Checking UI (Not for)");
        for(int i = 0; i < _inventory.Length; i++){
                Debug.Log("Checking UI (For)");
                _ItemsIMG[i].sprite = _itemsSprite[_inventory[i]];
                }
                // Типа обновляет все спрайты в инвентаре
                
        
    }
    
    private int GetItemIDInCell(int cellID)
    {
        return _inventory[cellID];
    }
}
