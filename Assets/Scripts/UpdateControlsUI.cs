using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateControlsUI : MonoBehaviour
{

    public TextMeshProUGUI up;
    public TextMeshProUGUI left;
    public TextMeshProUGUI down;
    public TextMeshProUGUI right;

    public void UpdateControls(Dictionary<string, KeyCode> controlsMap)
    {
        up.text = controlsMap["Forward"].ToString();
        left.text = controlsMap["Left"].ToString();
        down.text = controlsMap["Backward"].ToString();
        right.text = controlsMap["Right"].ToString();

    }
}
