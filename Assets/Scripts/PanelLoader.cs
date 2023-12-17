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
    private bool PanelOn = false;

    // Start is called before the first frame update
    void Start()
    {
        iconButton = transform.parent.GetComponent<Button>();
        Transform quit = transform.parent.Find("Quit");

        if (quit != null)
        {
            quitButton = quit.GetComponent<Button>();
        }

        if(PanelOn){
            ClosePanel();
        }
    }

    public void LoadPanel()
    {
        if(!PanelOn){
            iconButton.transition = Selectable.Transition.None;
            LoadedPanelAnimator.SetTrigger("LoadPanel");
            StartCoroutine(WaitForLoadPanelAnimation());
            PanelOn = true;
        }
    }

    IEnumerator WaitForLoadPanelAnimation()
    {
        yield return new WaitForSeconds(transitionTime);

        if (quitButton != null)
        {
            quitButton.interactable = true;
        }

        iconButton.transition = Selectable.Transition.SpriteSwap;
    }

    public void ClosePanel()
    {
        if(PanelOn){
            if (quitButton != null)
            {
                quitButton.interactable = false;
            }

            LoadedPanelAnimator.SetTrigger("ClosePanel");
            StartCoroutine(WaitForClosePanelAnimationAndClosePanel());
            PanelOn = false;
        }
    }

    IEnumerator WaitForClosePanelAnimationAndClosePanel()
    {
        yield return new WaitForSeconds(transitionTime);
    }
}
