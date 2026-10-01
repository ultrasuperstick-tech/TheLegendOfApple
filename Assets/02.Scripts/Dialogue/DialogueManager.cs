using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // 상호작용한 오브젝트의 dialogDetection
    DialogDetection dialogDetection;
    // UI에 보이는 이미지들
    public LetterBoxController letterBoxController;
    public Image player;
    public Sprite playerSprite;
    public Image otherImage;


    public GameObject dialog;
    public GameObject issac;
    int textIndex = 0;

    // 대화의 순서를 관리(배열)
    public string[] dialogs;

    // 대화창에 나올 텍스트
    public TMP_Text dialogText;

    private void Start()
    {
        player.sprite = playerSprite;
        textIndex = 0;
    }

    public void SetDialog(string[] otherDialogs, Sprite dialogerImage, DialogDetection dialogDetection)
    {
        // 다일로그 UI를 킴
        dialog.SetActive(true);

        // 상호작용한 오브젝트의 dialogDetection을 가져와서 넣어줌
        dialogs = otherDialogs;
        otherImage.sprite = dialogerImage;
        this.dialogDetection = dialogDetection;
        dialogText.text = dialogs[0];
        // 사과 밝게 새 어둡게
        otherImage.color = Color.gray;
    }

    private void Update()
    {
        // dialogDetection이 비어있으면 도ㅣ돌림
        if (dialogDetection == null)
        {
            return;
        }
        if (dialogDetection.canDailog == true)
        {
            // 레터박스 작동
            letterBoxController.ShowLetterBox();

            // 마우스를 클릭할때 마다 다음 대화로 넘어감
            if (Input.GetMouseButtonDown(0))
            {
                textIndex ++;

                // 짝수면 사과이미지가 밝고 홀수면 대하는 대상 이미지가 밝음
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

                // 대화가 끝나면(대화 배열의 길이를 넘거나 같으면 dialog와 관련돤 모든걸 끈다
                if (textIndex >= dialogs.Length)
                {
                    dialog.SetActive(false);
                    dialogDetection.canDailog = false;
                    dialogDetection.isDailog = false;
                    textIndex = 0;

                    letterBoxController.HideLetterBox();
                    return;
                }

                dialogText.text = dialogs[textIndex];
            }
        }
    }
}
