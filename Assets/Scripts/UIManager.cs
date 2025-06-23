using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //public PlayerMovment movment;
    public TMP_Text infoTopText;
    public TMP_Text infoBottomText;
    //public TMP_Text interactionText;
    public TMP_Text largrInfoText;
    public GameObject mailPanel;
    public GameObject bottomPanel;
    public GameObject largeInfoPanel;// zrobiæ na canvas nowy panel, wiêkszy ni¿ bottom (na 3 linijki!)
    public TMP_Text storyPanel;

    // Update is called once per frame
    void Update()
    {
      //  playerPointsText.text = movment.points.ToString();
    }

    public void SetBottomText(string value)
    {
        infoBottomText.text = value;
        bottomPanel.SetActive(true);
    }
    public void HideBottomText()
    {
        bottomPanel.SetActive(false);
    }

    public void SetDialogueText(string dialogue)
    {
      //dialogueText.text = dialogue;
       // if (dialogue != null && dialogue.Length > 0)
        {
          //dialoguePanel.SetActive(true);
        }
        //else
        {
           //dialoguePanel.SetActive(false);
        }
    }

    public void SetMailPanetVisibility(bool visible)
    {
        mailPanel.SetActive(visible);
        if (visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ShowLargePanel(string info)
    {
        largrInfoText.text = info;
        largeInfoPanel.SetActive(true);
    }

    // zrobiæ metodê ukrywaj¹c¹ jak dla bottom panel!
    public void HideLargeText()
    {
        largeInfoPanel.SetActive(false);
    }

    //

    
    public void SetStoryPanelVisibility(bool visible)
    {
        mailPanel.SetActive(visible);
        if (visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}