using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject ControlText;
    public GameObject WallText;
    public GameObject LongJumpText;
    public GameObject SpiralText;

    //game variables
    public string controlText;
    public string objectiveA;
    public string objectiveB;
    public string objectiveC;

    //text components
    TextMeshProUGUI tmp_controlText;
    TextMeshProUGUI tmp_wallText;
    TextMeshProUGUI tmp_jumpText;
    TextMeshProUGUI tmp_spiralText;

    //success color value
    Color success_color = new Color(0f, 255f, 0f);

    void Awake()
    {
        //setting up textmeshpro assets
        tmp_controlText = ControlText.GetComponent<TextMeshProUGUI>();
        tmp_wallText = WallText.GetComponent<TextMeshProUGUI>();
        tmp_jumpText = LongJumpText.GetComponent<TextMeshProUGUI>();
        tmp_spiralText = SpiralText.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        //setting text to the strings written in the inspector
        tmp_controlText.text = controlText;
        tmp_wallText.text = objectiveA;
        tmp_jumpText.text = objectiveB;
        tmp_spiralText.text = objectiveC;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "WallCheck")
        {
            //change wall objective text and color
            tmp_wallText.text = "COMPLETE";
            tmp_wallText.color = success_color;
            //change control text
            tmp_controlText.text = "";
        }

        if (collider.gameObject.tag == "LongJumpCheck")
        {
            //change long jump objective text and color
            tmp_jumpText.text = "COMPLETE";
            tmp_jumpText.color = success_color;
            //change control text (just in case)
            tmp_controlText.text = "";
        }

        if (collider.gameObject.tag == "SpiralCheck")
        {
            //change spiral objective text and color
            tmp_spiralText.text = "COMPLETE";
            tmp_spiralText.color = success_color;
            //change control text (just in case)
            tmp_controlText.text = "";
        }

        if (collider.gameObject.tag == "TutorialEnd")
        {
            //repurpose control text to tutorial end text
            tmp_controlText.text = "THANK YOU FOR PLAYING!";
            tmp_controlText.color = success_color;
        }
    }
}
