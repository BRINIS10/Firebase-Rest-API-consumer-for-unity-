# Firebase-Rest-API-consumer-for-unity-
I made this code to consume firebase realtime database in unity webgl. I made a multiplayer game , this code is perfect for Get and Put Data to and from database this code uses NewtonSoft.Json (free in unity assetstore)

Steps:
1- put your database link public static string databaseURI= "https://YOURDATABASE.firebaseio.com/";
2- to Get "yield return   FirebaseApiConsumer.Get(EasyCrudsManager.TableName<T>());
            Debug.Log("json =" + FirebaseApiConsumer.jsonGet);"
  3-to Put "FirebaseApiConsumer.instance.Put(PATHinDATABASE), objectToPut );"
  
