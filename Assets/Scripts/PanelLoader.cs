using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelLoader : MonoBehaviour
{
    public GameObject LoadedPanel;
    public Animator LoadedPanelAnimator;
    public float transitionTime = 2.5f;
    private Button iconButton;
    private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        LoadedPanel.SetActive(false);

        iconButton = transform.parent.GetComponent<Button>();
        Transform quit = transform.parent.Find("Quit");

        if (quit != null)
        {
            quitButton = quit.GetComponent<Button>();
        }
    }

    public void LoadPanel()
    {
        iconButton.transition = Selectable.Transition.None;
        LoadedPanel.SetActive(true);
        LoadedPanelAnimator.SetTrigger("LoadPanel");
        StartCoroutine(WaitForLoadPanelAnimation());
    }

    IEnumerator WaitForLoadPanelAnimation()
    {
        yield return new WaitForSeconds(transitionTime);

        if (quitButton != null)
        {
            quitButton.interactable = true;
        }

        iconButton.transition = Selectable.Transition.ColorTint;
    }

    public void ClosePanel()
    {
        if (quitButton != null)
        {
            quitButton.interactable = false;
        }

        LoadedPanelAnimator.SetTrigger("ClosePanel");
        StartCoroutine(WaitForClosePanelAnimationAndClosePanel());
    }

    IEnumerator WaitForClosePanelAnimationAndClosePanel()
    {
        yield return new WaitForSeconds(transitionTime);

        LoadedPanel.SetActive(false);

    }
}
