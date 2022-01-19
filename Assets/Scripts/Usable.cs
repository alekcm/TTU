using UnityEngine;
using UnityEngine.Events;

public class Usable : MonoBehaviour
{
    public Sprite UseIcon;
    protected GameObject UseButton_GameObject, MainHero_GameObject;
    protected UseButton UseButton_Script;

    public UnityEvent UseEvent;
    // Start is called before the first frame update

    public void StandartStart()
    {
        UseButton_GameObject = GameObject.Find("UseButton");
        MainHero_GameObject = GameObject.Find("Main Hero");
        UseButton_Script = UseButton_GameObject.GetComponent<UseButton>();
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        UseButton_Script.SetSettings(UseIcon, this);
    }
    public void OnTriggerExit2D(Collider2D collider2D)
    {
        UseButton_Script.SetStandartSettings();
    }
    
}
