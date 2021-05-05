using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    [HideInInspector]
   public string returnstr;

   public Text warningText;
    void Start()
    {
       warningText.gameObject.SetActive(false);
    }

    public string GetEnterEightMessage()
    {
        Warning enterEight = new Warning("Enter the 8 shape from any direction");

        return enterEight.message;
    }
    
    public string GetUTurnMessage()
    {
        Warning Uturn = new Warning("Turn on indicator.");

        return Uturn.message;
    }
    public string GetSlopeMessage()
    {
        Warning SlopeUp = new Warning("Stop between two yellow line for 3 second and go.");

        return SlopeUp.message;
    }
    public string GetSlowDownMessage()
    {
        Warning SlopeDown = new Warning("Drive Slow.");

        return SlopeDown.message;
    }
    public string GetStreetlightMessage()
    {
        Warning streetlight = new Warning("Wait see and go.");

        return streetlight.message;
    }
    public string GetBackParkingMessage()
    {
        Warning backparking = new Warning("Change to reverse gear.");

        return backparking.message;
    }

    public string GetReturnString()
    {
        
        return returnstr;
    }
    
    void Update()
    {
        
    }

    private void  OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "EnterEight")
        {
            AvtivateAndDeactivatePanel();

            warningText.text = GetEnterEightMessage();

        }

        if (other.gameObject.tag == "TurnOnIndicator")
        {
            AvtivateAndDeactivatePanel();
            warningText.text = GetUTurnMessage();
           
        }

        if (other.gameObject.tag == "StreetLight")
        {
            AvtivateAndDeactivatePanel();
            warningText.text = GetStreetlightMessage();
           
        }

        if (other.gameObject.tag == "StopOnSlope")
        {
            AvtivateAndDeactivatePanel();
            warningText.text = GetSlopeMessage();
           
        }

        if (other.gameObject.tag == "SlowDown")
        {
            AvtivateAndDeactivatePanel();
            warningText.text = GetSlowDownMessage();
            
        }

        if (other.gameObject.tag == "BackParking")
        {
            AvtivateAndDeactivatePanel();
            warningText.text = GetBackParkingMessage();
        }
        
    }

    private void AvtivateAndDeactivatePanel()
    {
        warningText.gameObject.SetActive(true);
        StartCoroutine(HidePopUp());
    }
    
    IEnumerator HidePopUp()
    {
 
        yield return new WaitForSeconds(2);
 
        warningText.gameObject.SetActive(false);
       
    }

    
}
