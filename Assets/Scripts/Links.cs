using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Links : MonoBehaviour
{
    public string links;
  
	public void SocialMedia(){
        Application.OpenURL(links);
    }

    public void SendEmail()
    {
        Application.OpenURL("mailto:" + links );
    }

}
