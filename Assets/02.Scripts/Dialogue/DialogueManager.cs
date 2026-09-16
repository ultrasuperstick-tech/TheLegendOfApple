using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    DialogDetection dialogDetection;
    public LetterBoxController letterBoxController;
    public Image player;
    public Sprite playerSprite;
    public Image otherImage;
    public GameObject dialog;
    public GameObject issac;
    int textIndex = 0;

    public string[] dialogs;

    public TMP_Text dialogText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        player.sprite = playerSprite;
        textIndex = 0;
    }
    public void SetDialog(string[] otherDialogs, Sprite dialogerImage, DialogDetection dialogDetection)
    {
        dialog.SetActive(true);

        dialogs = otherDialogs;
        otherImage.sprite = dialogerImage;
        this.dialogDetection = dialogDetection;
        dialogText.text = dialogs[0];
        // »ç°ú ¹à°Ô »õ ¾îµÓ°Ô
        otherImage.color = Color.gray;
    }

    private void Update()
    {

        if (dialogDetection == null)
        {
            return;
        }
        if (dialogDetection.canDailog == true)
        {
            letterBoxController.ShowLetterBox();

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
                    dialogDetection.isDailog = false;
                    letterBoxController.HideLetterBox();
                    return;
                }

                dialogText.text = dialogs[textIndex];
            }
        }
    }
}
