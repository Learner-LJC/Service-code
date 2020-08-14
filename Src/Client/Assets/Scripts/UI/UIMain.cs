using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour {

    public Text avatarName;
    public Text avatarLevel;

    //public Text avaterName1;

    //public Text avaterLevel1;
    // Use this for initialization
	void Start () {
        this.UpdateAvatar();
        //this.UpdateAvater1();
	}

    //void UpdateAvater1()
    //{
    //    this.avaterName1.text = string.Format("{0}[{1}]", User.Instance.CurrentCharacter.Name,
    //        User.Instance.CurrentCharacter.Id);
    //    this.avaterLevel1.text = User.Instance.CurrentCharacter.Level.ToString();
    //}
    void UpdateAvatar()
    {
        this.avatarName.text = string.Format("{0}[{1}]", User.Instance.CurrentCharacter.Name, User.Instance.CurrentCharacter.Id);
        this.avatarLevel.text = User.Instance.CurrentCharacter.Level.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackToCharSelect()
    {
        SceneManager.Instance.LoadScene("CharSelect");
        Services.UserService.Instance.SendGameLeave();
        
    }
}
