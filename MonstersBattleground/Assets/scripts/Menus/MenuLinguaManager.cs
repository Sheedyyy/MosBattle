using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
public class MenuLinguaManager : MonoBehaviour
{
    private void Start()
    {
        //salvar a lingua escolhida
        int ID = PlayerPrefs.GetInt("LocateKey", 0);
        buttonStuff(ID);
    }



    //
    private bool active = false;

    //
    public void buttonStuff(int LocaleID)
    {
        // se o active for verdade retorna
        if (active == true)
            return;
        StartCoroutine(setLocale(LocaleID));
    }


    //
    IEnumerator setLocale(int _localID)
    {
        //
        active = true;

        //
        yield return LocalizationSettings.InitializationOperation;

        //
        LocalizationSettings.SelectedLocale=LocalizationSettings.AvailableLocales.Locales[ _localID];

        //
        PlayerPrefs.SetInt("LocaleKey", _localID);

        //
        active = false;
    }

}
