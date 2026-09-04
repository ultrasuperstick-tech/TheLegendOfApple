using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image player;
    public Sprite playerSprite;
    public Image otherImage;
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
    }
    public void SetDialog(string[] otherDialogs, Sprite dialogerImage)
    {
        dialogs = otherDialogs;
        otherImage.sprite = dialogerImage;
        dialogText.text = dialogs[0];
        // »ç°ú ¹à°Ô »õ ¾îµÓ°Ô
        otherImage.color = Color.gray;
    }

    private void Update()
    {
        if (canDailog == true)
        {
            dialog.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                textIndex += 1;

                if(textIndex % 2 == 0)
                {
                    player.color = Color.white;
                    otherImage.color = Color.gray;
                }
                else
                {
                    player.color = Color.gray;
                    otherImage.color = Color.white;
                }

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
