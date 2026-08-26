using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image player;
    public Sprite playerSprite;
    public GameObject dialog;
    public bool canDailog;
    int textIndex;

    public string[] dialogs;

    public TMP_Text dialogText;

    private void Start()
    {
        player.sprite = playerSprite;
        canDailog = false;
        textIndex = 0;
    }

    private void Update()
    {
        if (canDailog == false)
        {
            textIndex = 0;
            dialog.SetActive(false);
        }
        else if (canDailog == true)
        {
            dialog.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                textIndex += 1;
                if (textIndex >= dialogs.Length)
                {
                    dialog.SetActive(false);
                }
                else
                {
                    dialogText.text = dialogs[textIndex];
                }
            }
        }
    }
}
