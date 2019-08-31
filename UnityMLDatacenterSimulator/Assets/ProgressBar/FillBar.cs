using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour {
    
    // Unity UI References
    public Slider slider;
    public Text displayText;
    public GameObject fill;
    
    // Create a property to handle the slider's value
    private float currentValue = 0f;
    public float CurrentValue {
        get {
            return currentValue;
        }
        set {
            currentValue = value;
            slider.value = currentValue;
            //fill.GetComponent<Image>().color = new Color32(100, 100, 100, 150);


            //Debug.Log("currentValue : " + currentValue);
            // Colour the server by heat
            if (currentValue > 0.50f)
            {
                // Devide 55 by .50 and multiply by the currentValue that is above 0.50
                float otherColor = (105 / 0.50f) * (currentValue - 0.50f);

                fill.GetComponent<Image>().color = new Color32((byte)(otherColor + 150), (byte)(-otherColor + 255), 150, 255);
            }
            else if (currentValue < 0)
            {
                fill.GetComponent<Image>().color = new Color32(150, 150, 255, 255);
            }
            else
            {
                fill.GetComponent<Image>().color = new Color32(150, 255, 150, 255);
            }



            //slider..color = new Color(125, 125, 125);
            displayText.text = (slider.value * 100).ToString("0.00") + "%";
        }
    }

    // Use this for initialization
    void Start () {
        CurrentValue = 0f;
    }
	
    // Update is called once per frame
    void Update () {
        CurrentValue += 0.0043f;
    }
}
