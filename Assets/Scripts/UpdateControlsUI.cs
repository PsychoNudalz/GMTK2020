using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateControlsUI : MonoBehaviour
{
    public CarController playerCar;

    public TextMeshProUGUI up;
    public TextMeshProUGUI left;
    public TextMeshProUGUI down;
    public TextMeshProUGUI right;

    private void Update()
    {
        rotateControlsToCar();
        UpdateControls();
    }

    public void UpdateControls()
    {
        Dictionary<string, KeyCode> controlsMap = playerCar.ControlsMap;
        up.text = controlsMap["Forward"].ToString();
        left.text = controlsMap["Left"].ToString();
        down.text = controlsMap["Backward"].ToString();
        right.text = controlsMap["Right"].ToString();

    }

    void rotateControlsToCar()
    {
        transform.rotation = playerCar.transform.rotation;
        up.transform.up = Vector2.up;
        left.transform.up = Vector2.up;
        right.transform.up = Vector2.up;
        down.transform.up = Vector2.up;

    }
}
