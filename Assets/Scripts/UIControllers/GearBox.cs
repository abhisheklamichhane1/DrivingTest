using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GearBox : MonoBehaviour
{
    public GameObject handle, N, N1, N2, G1, G2, G3, G4, G5, R, Gear;
    Vector3 initialGearNPosition, initialHPosition;

    public int gear = 0;

    public GameObject rearViewImage;
    public GameObject rearViewCam;
    bool inReverse;

    public CanvasGroup canvasGroup;
    public CarController carController;

    void Start()
    {
        initialGearNPosition = Gear.transform.position;
        rearViewImage.SetActive(false);
        rearViewCam.SetActive(false);
        inReverse = false;

    }

    private void Update()
    {

        float radius = 130; 
        Vector3 centerPosition = Gear.transform.position;

        
        float distance = Vector3.Distance(handle.transform.position, centerPosition); 

        if (distance > radius) 
        {
            Vector3 fromOriginToObject = handle.transform.position - centerPosition; 
            fromOriginToObject *= radius / distance; 
            handle.transform.position = centerPosition + fromOriginToObject;
            transform.position = handle.transform.position;

        }

        if (gear < 1)
        {
            carController.carSetting.LimitForwardSpeed = 0;
        }
        else if (gear < 2)
        {
            carController.carSetting.LimitForwardSpeed = 15;
        }
        else if (gear < 3)
        {
            carController.carSetting.LimitForwardSpeed = 20;
        }
        else if (gear < 4)
        {
            carController.carSetting.LimitForwardSpeed = 25;
        }
        else if (gear < 5)
        {
            carController.carSetting.LimitForwardSpeed = 30;
        }
        else if (gear < 6)
        {
            carController.carSetting.LimitForwardSpeed = 35;
        }
        else if (gear < 7)
        {
            carController.carSetting.LimitForwardSpeed = 12;
        }
    }
    public void DragGearN()
    {

        canvasGroup.alpha = .6f;
        handle.transform.position = Input.mousePosition;


    }
    public void DropGearN()
    {
        float distance = Vector3.Distance(handle.transform.position, N.transform.position);
        if (distance < 50)
        {
            canvasGroup.alpha = 1f;
            handle.transform.position = N.transform.position;
            gear = 0;
            Debug.Log(gear);
            rearFalse();
        }

    }


    public void DropGearN1()
    {
        float distance = Vector3.Distance(handle.transform.position, N1.transform.position);
        if (distance < 40)
        {
            canvasGroup.alpha = 1f;
            handle.transform.position = N.transform.position;
            gear = 0;
            rearFalse();
        }

    }

    public void DropGearN2()
    {
        float distance = Vector3.Distance(handle.transform.position, N2.transform.position);
        if (distance < 40)
        {
            canvasGroup.alpha = 1f;
            handle.transform.position = N.transform.position;
            gear = 0;
            rearFalse();
        }

    }



    public void DropGear1()
    {
        float distance = Vector3.Distance(handle.transform.position, G1.transform.position);
        if (distance < 40)
        {
            canvasGroup.alpha = 1f;
            handle.transform.position = G1.transform.position;
            gear = 1;
            Debug.Log(gear);
            rearFalse();
        }

    }
    public void DropGear2()
    {
        float distance = Vector3.Distance(handle.transform.position, G2.transform.position);
        if (distance < 40)
        {
            canvasGroup.alpha = 1f;
            handle.transform.position = G2.transform.position;
            gear = 2;
            Debug.Log(gear);
            rearFalse();
        }

    }
    public void DropGear3()
    {
        float distance = Vector3.Distance(handle.transform.position, G3.transform.position);

        if (distance < 40)
        {
            canvasGroup.alpha = 1f;
            handle.transform.position = G3.transform.position;
            gear = 3;
            Debug.Log(gear);
        }

    }
    public void DropGear4()
    {
        float distance = Vector3.Distance(handle.transform.position, G4.transform.position);
        if (distance < 40)
        {
            canvasGroup.alpha = 1f;
            handle.transform.position = G4.transform.position;
            gear = 4;
            Debug.Log(gear);
            rearFalse();
        }

    }
    public void DropGear5()
    {
        float distance = Vector3.Distance(handle.transform.position, G5.transform.position);

        if (distance < 40)
        {
            canvasGroup.alpha = 1f;
            handle.transform.position = G5.transform.position;
            gear = 5;
            Debug.Log(gear);
            rearFalse();
        }

    }
    public void DropGearR()
    {
        float distance = Vector3.Distance(handle.transform.position, R.transform.position);

        if (distance < 40)
        {
            canvasGroup.alpha = 1f;
            handle.transform.position = R.transform.position;
            gear = 6;
            Debug.Log(gear);
            rearMirrior();
        }

    }
    public void rearMirrior()
    {
        if (inReverse == false)
        {
            rearViewCam.SetActive(true);
            rearViewImage.SetActive(true);
            inReverse = true;
        }
    }
    public void rearFalse()
    {
        if (inReverse == true)
        {
            rearViewCam.SetActive(false);
            rearViewImage.SetActive(false);
            inReverse = false;
        }
    }

}