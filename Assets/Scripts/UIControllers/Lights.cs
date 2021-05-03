using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{

    public bool on = false;
    public bool on2 = false;
    public bool on3 = false;


    public bool LeftIndicator = false;
    public bool RightIndicator = false;


    public GameObject leftIndicator;
    public GameObject rightIndicator;


    public Material ILM;
    public Material IRM;

    private float timer = 0.5f;
    private float timer2 = 0.5f;
    private float btimer = 0.5f;
    private float btimer2 = 0.5f;

    private void Start()
    {
        leftIndicator.SetActive(false);
        rightIndicator.SetActive(false);

        ILM.DisableKeyword("_EMISSION");
        IRM.DisableKeyword("_EMISSION");
    }

    private void Update()
    {
        if (LeftIndicator)
        {
            if (timer >= 0f)
            {
                timer -= Time.deltaTime;
                leftIndicator.SetActive(true);
                ILM.EnableKeyword("_EMISSION");
                timer2 = 0.5f;
            }
            if (timer <= 0f)
            {
                leftIndicator.SetActive(false);
                ILM.DisableKeyword("_EMISSION");
                timer2 -= Time.deltaTime;
                if (timer2 <= 0f) timer = 0.5f;
            }
        }
        else
        {
            leftIndicator.SetActive(false);
            ILM.DisableKeyword("_EMISSION");
        }

        if (RightIndicator)
        {
            if (btimer >= 0f)
            {
                btimer -= Time.deltaTime;
                rightIndicator.SetActive(true);
                IRM.EnableKeyword("_EMISSION");
                btimer2 = 0.5f;
            }
            if (btimer <= 0f)
            {
                rightIndicator.SetActive(false);
                IRM.DisableKeyword("_EMISSION");
                btimer2 -= Time.deltaTime;
                if (btimer2 <= 0f) btimer = 0.5f;
            }
        }
        else
        {
            rightIndicator.SetActive(false);
            IRM.DisableKeyword("_EMISSION");
        }

    }

    private void OnGUI()
    {
        //Rects

        Rect Rect4 = new Rect(885f, 50, 150, 50);
        Rect Rect5 = new Rect(1143.75f, 50, 150, 50);


        //Screen scaling
        Vector3 scale;
        float originalWidht = 2560;
        float originalHeight = 1640;

        scale.x = Screen.width / originalWidht;
        scale.y = Screen.height / originalHeight;
        scale.z = 1;
        Matrix4x4 svMat = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, scale);

        GUI.backgroundColor = Color.clear;



        if (GUI.Button(Rect4, "Left Indicators"))
        {
            timer = 0.5f;
            LeftIndicator = false;
            RightIndicator = false;
            if (on2 == false)
            {
                on2 = true;
                on = false;
                on3 = false;
                if (LeftIndicator == false)
                {
                    LeftIndicator = true;
                    RightIndicator = false;
                    /*IL.active = true;
                    ILM.EnableKeyword("_EMISSION");*/
                }
            }


            else
            {
                on2 = false;
                LeftIndicator = false;
                /*IL.active = false;
                ILM.DisableKeyword("_EMISSION");*/
            }
        }
        if (GUI.Button(Rect5, "Right Indicators"))
        {
            btimer = 0.5f;
            LeftIndicator = false;
            RightIndicator = false;
            if (on == false)
            {
                on = true;
                on2 = false;
                on3 = false;
                if (RightIndicator == false)
                {
                    RightIndicator = true;
                    LeftIndicator = false;
                    //IR.active = true;
                    //IRM.EnableKeyword("_EMISSION");
                }
            }
            else
            {
                on = false;
                RightIndicator = false;
                //IR.active = false;
                //IRM.DisableKeyword("_EMISSION");
            }
        }


    }
}
