using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
public class MenuLinguaManager : MonoBehaviour
{
    private void Start()
    {
        //salvar a lingua escolhida
        // Obtém o valor da chave "LocaleKey" das preferências do jogador
        int ID = PlayerPrefs.GetInt("LocateKey", 0);
        // Chama o método buttonStuff com o ID do local escolhido
        buttonStuff(ID);
    }



    // Se a rotina já estiver ativa, retorna imediatamente
    private bool active = false;

    
    public void buttonStuff(int LocaleID)
    {
        // Se a rotina já estiver ativa, retorna imediatamente
        if (active == true)
            return;

        // Inicia a rotina setLocale com o ID do local
        StartCoroutine(setLocale(LocaleID));
    }


    
    IEnumerator setLocale(int _localID)
    {
        // Define a rotina como ativa
        active = true;

        // Aguarda a conclusão da operação de inicialização da localização
        yield return LocalizationSettings.InitializationOperation;

        //Define o local selecionado com base no ID fornecido
        LocalizationSettings.SelectedLocale=LocalizationSettings.AvailableLocales.Locales[ _localID];

        // Salva o ID do local nas preferências do jogador
        PlayerPrefs.SetInt("LocaleKey", _localID);

        //Define a rotina como inativa
        active = false;
    }

}
