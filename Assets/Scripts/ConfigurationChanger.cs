using UnityEngine;
using TMPro;

public class ConfigurationChanger : MonoBehaviour
{
    public int playerId;
    private LocalSettings settings;

    private void Start() {
        settings=FindObjectOfType<SettingsManager>().GetConfiguration(playerId);
    }

    private bool changingForwardKey = false;
    private bool changingBackwardKey = false;
    private bool changingLeftKey = false;
    private bool changingRightKey = false;
    private bool changingBombKey = false;

    private void Update()
    {
        if (changingForwardKey)
        {
            if (Input.anyKeyDown)
            {
                settings.upKey = GetPressedKey();
                ChangeName(0,settings.upKey);//Posición Segun Organización Hijos
                changingForwardKey = false;
            }
        }
        else if (changingBackwardKey)
        {
            if (Input.anyKeyDown)
            {
                settings.downKey = GetPressedKey();
                ChangeName(1,settings.downKey);//Posición Segun Organización Hijos
                changingBackwardKey = false;
            }
        }
        else if (changingLeftKey)
        {
            if (Input.anyKeyDown)
            {
                settings.leftKey = GetPressedKey();
                ChangeName(5,settings.leftKey);//Posición Segun Organización Hijos
                changingLeftKey = false;
            }
        }
        else if (changingRightKey)
        {
            if (Input.anyKeyDown)
            {
                settings.rightKey = GetPressedKey();
                ChangeName(2,settings.rightKey);//Posición Segun Organización Hijos
                changingRightKey = false;
            }
        }
        else if (changingBombKey)
        {
            if (Input.anyKeyDown)
            {
                settings.bombKey = GetPressedKey();
                ChangeName(3,settings.bombKey);//Posición Segun Organización Hijos
                changingBombKey = false;
            }
        }
    }

    private KeyCode GetPressedKey()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                return keyCode;
            }
        }
        return KeyCode.None;
    }

    public void ChangeForwardKey()
    {
        changingForwardKey = true;
    }

    public void ChangeBackwardKey()
    {
        changingBackwardKey = true;
    }

    public void ChangeLeftKey()
    {
        changingLeftKey = true;
    }

    public void ChangeRightKey()
    {
        changingRightKey = true;
    }

    public void ChangeBombKey()
    {
        changingBombKey = true;
    }

    private void ChangeName(int posId,KeyCode key){
        gameObject.transform.GetChild(posId).GetChild(0).GetComponent<TextMeshProUGUI>().text=key.ToString();
    }
}
