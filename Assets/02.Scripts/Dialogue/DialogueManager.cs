using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image player;
    public Sprite playerSprite;
    public GameObject dialog;
    public bool canDailog;
    public bool isDailog;
    int textIndex = 0;

    public string[] dialogs;

    public TMP_Text dialogText;

    private void Start()
    {
        player.sprite = playerSprite;
        canDailog = false;
        isDailog = true;
        textIndex = 0;
        dialogText.text = dialogs[0];
    }

    private void Update()
    {
        if (canDailog == true)
        {
            dialog.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                textIndex += 1;

                if (textIndex >= dialogs.Length)
                {
                    dialog.SetActive(false);
                    canDailog = false;
                    isDailog = false;
                    return;
                }

                dialogText.text = dialogs[textIndex];
            }
            
        }
    }
}
