using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class FirebaseApiConsumer : MonoBehaviour
{
    public static FirebaseApiConsumer instance;
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
      // StartCoroutine(GetTest());
     // Put("allLavelsTest/" + SystemInfo.deviceUniqueIdentifier,System.DateTime.UtcNow);
    }
    IEnumerator GetTest()
    {
        yield return StartCoroutine(Get("allLavelsTest/" + SystemInfo.deviceUniqueIdentifier));
        Debug.Log("json get= "+jsonGet);
    }
    public static string jsonGet;
    public static string databaseURI= "https://vr-beat-saber.firebaseio.com/";
   public static string finalUrl;
    static string BuildFinalURI(string URIInDatabae)
    {
        finalUrl = databaseURI + "/" + URIInDatabae + ".json";
        return finalUrl;
    }
   public static IEnumerator  Get(string urlInDataBase)
    {
    
        WWW www = new WWW(BuildFinalURI(urlInDataBase));
        yield return www;
        jsonGet = www.text;
    }
    
    static string jsonPut;
    public  void Put(string URIInDatabase, object obj)
    {
        StartCoroutine(PutRoutine(URIInDatabase, obj));
    }
  static  IEnumerator PutRoutine(string URIInDatabase,object obj)
    {
        jsonPut = JsonConvert.SerializeObject(obj);
        using (UnityWebRequest www = UnityWebRequest.Put(BuildFinalURI(URIInDatabase),jsonPut))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Upload complete!");
            }
        }
    }

}
