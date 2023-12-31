using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;

// This script contained in InputHandler
public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    Inventory inventory;

    private void Awake(){
        _mainCamera = Camera.main;
        inventory = Inventory.instance;
    }

//  This method is responsible for the click event
    public void OnClick(InputAction.CallbackContext context){
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if(!rayHit.collider) return;

        // Convey the item type to Inventory
        if (rayHit.collider != null && (rayHit.collider.CompareTag("Item") || rayHit.collider.CompareTag("Interactable"))){
            Item itemClicked = rayHit.collider.GetComponent<ItemInteractable>().item;
                
            if (inventory.Add(itemClicked))
                Destroy(rayHit.collider.gameObject);
        }
    }


}
