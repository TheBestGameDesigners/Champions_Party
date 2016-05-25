using UnityEngine;
using System.Collections;

public class QuitApplication : MonoBehaviour {

	public void Quit()
	{
	
		Application.LoadLevel(0);
	
	}
}
