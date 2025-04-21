using UnityEngine;
using UnityEngine.UI;

public class NewMatchButtonOnClick : MonoBehaviour
{
    public Button myButton;

    void Start()
    {
        myButton.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        GameManager.IsNewMatchAsked= true;
    }
}
