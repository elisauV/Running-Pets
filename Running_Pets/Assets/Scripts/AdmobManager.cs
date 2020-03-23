using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class AdmobManager : MonoBehaviour
{

    public static AdmobManager Instance { set; get; }

    [SerializeField]
    private string BannerID;
    [SerializeField]
    private string VideoID;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Admob.Instance().initAdmob(BannerID, VideoID);
        Admob.Instance().setForChildren(true);
        //Admob.Instance().setTesting(true); // remove this line when you publish.
        Admob.Instance().loadInterstitial();
    }

    public void ShowBanner()
    {
#if UNITY_EDITOR
        Debug.Log("Unable to play Ads from Editor");
#elif UNITY_ANDROID
		Admob.Instance ().showBannerRelative (AdSize.Banner, AdPosition.TOP_RIGHT, 5);
#endif
        StartCoroutine("Remover");
    }
    

    public void ShowVideo()
    {
#if UNITY_EDITOR
        Debug.Log("Unable to play Ads from Editor");
#elif UNITY_ANDROID
		if (Admob.Instance ().isInterstitialReady ()) 
		{
			Admob.Instance ().showInterstitial ();
		}
#endif
    }
IEnumerator Remover()
{
    yield return new WaitForSeconds(10);
        Admob.Instance().removeBanner();
    }
}
