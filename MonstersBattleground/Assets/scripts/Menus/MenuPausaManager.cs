using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausaManager : MonoBehaviour
{
    // Referência para o GameObject do menu de pausa
    [SerializeField] private GameObject pauseMenu;

    // Referência para o GameObject do menu de opções
    [SerializeField] private GameObject optionsMenu;

    // Variável para rastrear se o jogador está no menu de opções
    private bool isInOptions = false;

    // Atualiza é chamado uma vez por frame
    void Update()
    {
        // Verifica se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Se o jogador não está no menu de opções
            if (!isInOptions)
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

    // Função para fechar o menu de opções
    public void CloseOptions()
    {
        // Desativa o menu de opções
        optionsMenu.SetActive(false);

        // Ativa o menu de pausa
        pauseMenu.SetActive(true);

        // Define que o jogador não está mais no menu de opções
        isInOptions = false;
    }

    public void VoltarMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
