using UnityEngine;

public class GridGameManager : MonoBehaviour
{
    public TMPro.TMP_Text accuracyText;

    void Update()
    {
        float accuracy = DataManager.shots > 0 ? (float)DataManager.hits / DataManager.shots * 100 : 0f;
        accuracyText.text = "Accuracy: " + accuracy.ToString("F1") + "%";
    }
}
