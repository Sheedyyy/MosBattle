using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausaManager : MonoBehaviour
{
    // Referência para o GameObject do menu de pausa
    [SerializeField] private GameObject pauseMenu;

    // Referência para o GameObject do menu de opções
    [SerializeField] private GameObject optionsMenu;

    // Referência para o GameObject do menu de Linguas
    [SerializeField] private GameObject LinguaMenu;

    // Variável para rastrear se o jogador está no menu de opções
    private bool isInOptions = false;
    private bool isInLinguas = false;

    // Atualiza é chamado uma vez por frame
    void Update()
    {
        // Verifica se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Se o jogador não está no menu de opções ou de linguas
            if (!isInOptions || !isInLinguas)
            {
                // Se o menu de pausa estiver ativo, desative-o e despausa o jogo
                if (pauseMenu.activeSelf)
                {
                    ContinueGame();
                } 
            
                // Se estiver inativo, ative-o e pausa o jogo
                else
                {
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0;
                }
            }

           
        }


    }

    // Função para continuar o jogo
    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Função para abrir o menu de opções
    public void OpenOptions()
    {
        // Desativa o menu de pausa
        pauseMenu.SetActive(false);

        // Ativa o menu de opções
        optionsMenu.SetActive(true);

        // Define que o jogador está no menu de opções
        isInOptions = true;
    }


    // Função para abrir o menu de Liguas
    public void OpenLingua()
    {
        // Desativa o menu de pausa
        pauseMenu.SetActive(false);

        // Ativa o menu de Linguas
        LinguaMenu.SetActive(true);

        // Define que o jogador está no menu de Linguas
        isInLinguas = true;
    }

    // Função para fechar o menu de opções
    public void CloseOptions()
    {
        // Desativa o menu de opções
        optionsMenu.SetActive(false);
        Time.timeScale = 1;


        // Define que o jogador não está mais no menu de opções
        isInOptions = false;
        
    }

    public void CloseLingua()
    {
        // Ativa o menu de pausa
        LinguaMenu.SetActive(false);
        Time.timeScale = 1;

        // Define que o jogador não está mais no menu de opções
        isInLinguas = false;

    }

    
    public void VoltarMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
