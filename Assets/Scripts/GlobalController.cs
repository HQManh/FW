using UnityEngine;
using UnityEngine.Events;
//using MoreMountains.NiceVibrations;

#if UNITY_IOS
using UnityEngine.iOS;
#elif UNITY_ANDROID
//using Google.Play.Review;
#endif

public class MissionSuccessEvent : UnityEvent<int> { }

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance { get; set; }
    public static bool IsSoundOn { get; set; }
    public static bool IsMusicOn { get; set; }


    private void Awake()
    {
        Instance = this;
        int t = PlayerPrefs.GetInt("IsSoundOn", 1);
        if(t==1)
        {
            IsSoundOn = true;
        }else IsSoundOn = false;
        t = PlayerPrefs.GetInt("IsMusicOn", 1); 
        if(t==1)
        {
            IsMusicOn = true;
        } else IsMusicOn = false;
    }


 
  
}
