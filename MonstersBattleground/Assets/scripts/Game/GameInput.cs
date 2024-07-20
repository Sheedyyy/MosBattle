using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{


    private const string PLAYER_PREFS_BINDINGS = "InputBindings";


    public static GameInput Instance { get; private set; }



    
    public event EventHandler OnBindingRebind;


    public enum Binding
    {
        Move_Up,
        Move_Down,
        Move_Left,
        Move_Right,
        
    }


    private InputPlayer inputPlayer;


    private void Awake()
    {
        Instance = this;


        inputPlayer = new InputPlayer();

        if (PlayerPrefs.HasKey(PLAYER_PREFS_BINDINGS))
        {
            inputPlayer.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PLAYER_PREFS_BINDINGS));
        }

        inputPlayer.PlayerMovent.Enable();

       
    }

    
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = inputPlayer.PlayerMovent.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

    public string GetBindingText(Binding binding)
    {
        switch (binding)
        {
            default:
            case Binding.Move_Up:
                return inputPlayer.PlayerMovent.Move.bindings[1].ToDisplayString();
            case Binding.Move_Down:
                return inputPlayer.PlayerMovent.Move.bindings[2].ToDisplayString();
            case Binding.Move_Left:
                return inputPlayer.PlayerMovent.Move.bindings[3].ToDisplayString();
            case Binding.Move_Right:
                return inputPlayer.PlayerMovent.Move.bindings[4].ToDisplayString();
            
        }
    }

    public void RebindBinding(Binding binding, Action onActionRebound)
    {
        inputPlayer.PlayerMovent.Disable();

        InputAction inputAction;
        int bindingIndex;

        switch (binding)
        {
            default:
            case Binding.Move_Up:
                inputAction = inputPlayer.PlayerMovent.Move;
                bindingIndex = 1;
                break;
            case Binding.Move_Down:
                inputAction = inputPlayer.PlayerMovent.Move;
                bindingIndex = 2;
                break;
            case Binding.Move_Left:
                inputAction = inputPlayer.PlayerMovent.Move;
                bindingIndex = 3;
                break;
            case Binding.Move_Right:
                inputAction = inputPlayer.PlayerMovent.Move;
                bindingIndex = 4;
                break;
            
        }

        inputAction.PerformInteractiveRebinding(bindingIndex)
            .OnComplete(callback => {
                callback.Dispose();
                inputPlayer.PlayerMovent.Enable();
                onActionRebound();

                PlayerPrefs.SetString(PLAYER_PREFS_BINDINGS, inputPlayer.SaveBindingOverridesAsJson());
                PlayerPrefs.Save();

                OnBindingRebind?.Invoke(this, EventArgs.Empty);
            })
            .Start();
    }

}