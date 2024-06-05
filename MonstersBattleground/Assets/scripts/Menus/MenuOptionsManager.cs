using UnityEngine;

public class MenuOptionsManager : MonoBehaviour
{
   public void ChangeScreen()
   {
       Screen.fullScreen = !Screen.fullScreen;
       print("Screen Changed!");
   }
}
