using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausaManager : MonoBehaviour
{
    // Refer�ncia para o GameObject do menu de pausa
    [SerializeField] private GameObject pauseMenu;

    // Refer�ncia para o GameObject do menu de op��es
    [SerializeField] private GameObject optionsMenu;

    // Vari�vel para rastrear se o jogador est� no menu de op��es
    private bool isInOptions = false;

    // Atualiza � chamado uma vez por frame
    void Update()
    {
        // Verifica se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Se o jogador n�o est� no menu de op��es
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

    // Fun��o para continuar o jogo
    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Fun��o para abrir o menu de op��es
    public void OpenOptions()
    {
        // Desativa o menu de pausa
        pauseMenu.SetActive(false);

        // Ativa o menu de op��es
        optionsMenu.SetActive(true);

        // Define que o jogador est� no menu de op��es
        isInOptions = true;
    }

    // Fun��o para fechar o menu de op��es
    public void CloseOptions()
    {
        // Desativa o menu de op��es
        optionsMenu.SetActive(false);

        // Ativa o menu de pausa
        pauseMenu.SetActive(true);

        // Define que o jogador n�o est� mais no menu de op��es
        isInOptions = false;
    }

    public void VoltarMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}