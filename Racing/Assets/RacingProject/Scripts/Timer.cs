
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
   public Text lapTimeText = null;
   public Text bestTimeText = null;
  [ HideInInspector ] public bool CheckPointReached = true;
   public int lapCountTotal = 3;
    public Text lapCounterText = null;
    public TextMesh lapText = null;
    public VehicleBehaviour.WheelVehicle vehicle;
    public GameObject raceCompleteUi = null;

    float startTime;
    float ellapsedTime;
    float bestTime = 1000;
    int lapCounter = 0;

    bool startCounting = false;
    bool enableBestTime = false;
    bool countTime = false;

    private void Update()
    {
        if ( startCounting )
        {
            startCounting = false;
            startTime = Time.time;
            countTime = true;
        }

        if ( countTime )
        {
            ellapsedTime = Time.time - startTime;
            lapTimeText.text = ellapsedTime.ToString( "f2" );
        }
        lapCounterText.text = lapCounter.ToString() + " / " + lapCountTotal ;

        lapText.text = LapLabel ();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.name == "Trigger" )
        {
            if ( ellapsedTime <= bestTime && enableBestTime && CheckPointReached )
            {
                bestTime = ellapsedTime;
                bestTimeText.text = lapTimeText.text;

            }
            if ( CheckPointReached )
            {
                CheckPointReached = false;
                startCounting = true;
                lapCounter++;
            }
            if (lapCounter == lapCountTotal + 1)
            {
                vehicle.IsPlayer = false;
                raceCompleteUi.SetActive (true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ( other.name == "Trigger" )
        {
            enableBestTime = true;
        }
    }
    string LapLabel ()
    {
        string val = "";
        switch(lapCounter)
        {
            case 0: val = "START!"; break;
            case 1: val = "Lap: 2"; break;
            case 2: val = "Lap: 3"; break;
            case 3: val = "FINISH!"; break;
            case 4: val = ""; break;
        }
        return val;
    }

    
    public void GoToLevel ( int id )
    {
        SceneManager.LoadScene ( id );
    }

}
