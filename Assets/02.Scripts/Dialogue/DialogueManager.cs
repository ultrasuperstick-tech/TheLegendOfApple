using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    DialogDetection dialogDetection;
    public Image player;
    public Sprite playerSprite;
    public Image otherImage;
    public GameObject dialog;
    public GameObject issac;
    public bool isDailog; // 대화 가능하냐 - 끝나면 false.
    int textIndex = 0;

    public string[] dialogs;

    public TMP_Text dialogText;

    private void Start()
    {
        player.sprite = playerSprite;
        isDailog = true;
        textIndex = 0;

    }
    public void SetDialog(string[] otherDialogs, Sprite dialogerImage, DialogDetection dialogDetection)
    {
        dialogs = otherDialogs;
        otherImage.sprite = dialogerImage;
        this.dialogDetection = dialogDetection;
        dialogText.text = dialogs[0];
        // 사과 밝게 새 어둡게
        otherImage.color = Color.gray;
    }

    private void Update()
    {
        if (dialogDetection.canDailog == true)
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
                    dialogDetection.canDailog = false;
                    isDailog = false;
                    return;
                }

                dialogText.text = dialogs[textIndex];
            }
        }
    }
}
