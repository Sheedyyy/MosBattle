using UnityEngine;

public class MapMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mapMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mapMenu.SetActive(!mapMenu.activeSelf);
        }
    }
}
