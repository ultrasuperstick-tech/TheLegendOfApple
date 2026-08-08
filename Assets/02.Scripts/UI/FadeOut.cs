using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    Color32 color;
    RobinController robinController;
    GameObject robin;
    bool fadeOutStart;
    float alpha;
    private void Awake()
    {
        robin = GameObject.Find("Robin");
        color = this.gameObject.GetComponent<Image>().color;
        robinController = robin.GetComponent<RobinController>();
    }

    private void Start()
    {
        alpha = 0f;
        color = new Color(0, 0, 0, alpha);
    }

    private void Update()
    {
        fadeOutStart = robinController.canFly;

        if (fadeOutStart == false)
        {
            alpha -= Time.fixedDeltaTime;
            color = new Color(0, 0, 0, 1 + alpha);
        }

        if (fadeOutStart == true)
        {
            alpha += Time.fixedDeltaTime;
            color = new Color(0, 0, 0, 0 + alpha);
        }
        
        this.gameObject.GetComponent<Image>().color = color;
    }
}
