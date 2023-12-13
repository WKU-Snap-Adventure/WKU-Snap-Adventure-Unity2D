using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    Inventory inventory;

    private void Awake(){
        _mainCamera = Camera.main;
        inventory = Inventory.instance;
    }

    public void OnClick(InputAction.CallbackContext context){
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if(!rayHit.collider) return;

        Debug.Log(rayHit.collider.gameObject.name);

        Item itemClicked = rayHit.collider.GetComponent<ItemInteractable>().item;
        if (inventory.Add(itemClicked))
            Destroy(rayHit.collider.gameObject);
    }


}
