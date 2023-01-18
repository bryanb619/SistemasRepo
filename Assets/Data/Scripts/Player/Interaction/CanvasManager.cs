using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject _interactionPanel;
    [SerializeField] private Text _interactionText;
    [SerializeField] private Image[] _inventoryIcons;

    public static bool Inventory_Active = false;
    public GameObject Inventory_Canvas;

    void Start()
    {
        HideInteractionPanel();
    }
    private void Update()
    {
        // look for tab to activate/deactivate inventory
        //LookForTAB_KeyCode();

    }

    public void HideInteractionPanel()
    {
        _interactionPanel.SetActive(false);
    }

    // Activate Interaction Panel with X message
    public void ShowInteractionPanel(string message)
    {
        _interactionText.text = message;
        _interactionPanel.SetActive(true);


    }


    public void SetInventoryIcon(int i, Sprite icon)
    {
        _inventoryIcons[i].sprite = icon;
        _inventoryIcons[i].color = Color.white;
    }

    public void ClearInventoryIcons()
    {
        // if(numbers!= null)
        for (int i = 0; i < _inventoryIcons.Length; ++i)
        {
            _inventoryIcons[i].sprite = null;
            _inventoryIcons[i].color = Color.clear;
        }



    }
    private void LookForTAB_KeyCode()
    {
        // Get Tab input to manage inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // is active hide inventory
            if (Inventory_Active)
            {
                Hide_Inventory();
            }

            // if not active show inventory
            else
            {
                Show_Inventory();
            }
        }
    }


    // Verificar a necessidade de inventario

    public void Hide_Inventory()
    {
        // canvas settings
        Inventory_Canvas.SetActive(false);
        Inventory_Active = false;

        /* cursor settings
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        */
    }

    public void Show_Inventory()
    {
        // Canvas settings
        Inventory_Canvas.SetActive(true);
        Inventory_Active = true;

        /* cursor setting
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        */
    }
}
