using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeLoader : MonoBehaviour
{

    public Text furnitureName;
    public Transform materialContainer;
    public GameObject material;
    public Image outcomeImage;

    void Start()
    {
        furnitureName.text = "Craft Table";
    }

    public void LoadRecipe(Recipe recipe)
    {
        furnitureName.text = recipe.name;
        outcomeImage.enabled = true;
        outcomeImage.sprite = recipe.icon;

        for (int i = 0; i < recipe.items.Length; i++)
        {
            if (materialContainer != null){
                GameObject newMaterial = Instantiate(material);

                RectTransform materialTrans = newMaterial.GetComponent<RectTransform>();

                materialTrans.SetParent(materialContainer, false);

                materialTrans.localScale = Vector3.one;

                Image image = materialTrans.Find("Image").gameObject.GetComponent<Image>();

                image.enabled = true;
                image.sprite = recipe.items[i].icon;
            }
            else
            {
                Debug.LogWarning("ItemSlotContainer not assigned. The InventorySlot will be a root-level object.");
            }
        }
    }

    public void ClearRecipe()
    {
        furnitureName.text = string.Empty;
        outcomeImage.enabled = false;
        outcomeImage.sprite = null;

        if (materialContainer != null)
        {
            foreach (Transform child in materialContainer)
            {
                Destroy(child.gameObject);
            }
        }
        else
        {
            Debug.LogWarning("MaterialContainer not assigned. Unable to clear recipe.");
        }
    }


}
