using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int[] _inventory;
    [SerializeField] private int _selectedInvCell = 4;
    [SerializeField] private int SavedI_GetNullCell;

    [SerializeField] private GameObject SelectArrow;

    [SerializeField] private Image[] _ItemsIMG;

    [SerializeField] private Sprite[] _itemsSprite;

    [SerializeField] private Vector2[] TransformsForArrow;

    /*
    ИДшники предметов
    0 - Пустота
    1 - капкан 
    */
    private void Start()
    {
        GetNullCell();
        SelectArrow.AddComponent<RectTransform>();
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
        if(Input.GetKeyDown("1"))
        {
            SelectCell(1);
        }else if(Input.GetKeyDown("2"))
        {
            SelectCell(2);
        }else if(Input.GetKeyDown("3"))
        {
            SelectCell(3);
        }else if(Input.GetKeyDown("4"))
        {
            SelectCell(4);
        }else if(Input.GetKeyDown("5"))
        {
            SelectCell(5);
        }
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
    
    public int GetItemIDInCell(int cellID)
    {
        return _inventory[cellID];
    }
    public void GiveTraps()
    {
        GetNullCell();
        SetItem(SavedI_GetNullCell, 1);
    }
    public void SelectCell(int numCell)
    {
        if(numCell == 1)
        {
            SelectArrow.GetComponent<RectTransform>().anchoredPosition = TransformsForArrow[0];
            _selectedInvCell = 0;
        }else if(numCell == 2)
        {
            SelectArrow.GetComponent<RectTransform>().anchoredPosition = TransformsForArrow[1];
            _selectedInvCell = 1;
        }else if(numCell == 3)
        {
            SelectArrow.GetComponent<RectTransform>().anchoredPosition = TransformsForArrow[2];
            _selectedInvCell = 2;
        }else if(numCell == 4)
        {
            SelectArrow.GetComponent<RectTransform>().anchoredPosition = TransformsForArrow[3];
            _selectedInvCell = 3;
        }else if(numCell == 5)
        {
            SelectArrow.GetComponent<RectTransform>().anchoredPosition = TransformsForArrow[4];
            _selectedInvCell = 4;
        }
    }
    public int GetSelectedCell()
    {
        return _selectedInvCell;
    }
    public void DeleteTrapFromInv(int DelCellNum)
    {
        _inventory[DelCellNum] = 0;
    }
}
