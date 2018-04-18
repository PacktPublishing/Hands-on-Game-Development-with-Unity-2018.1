using SenLabs.GameFramework.InputManagement;
using UnityEngine;

public class SampleCharacterController : MonoBehaviour
{
	private InputManager inputManager;

	void Start () {
		inputManager = new InputManager(new SampleBindings());	
	}
	
	void Update ()
	{
		CheckForInput();
	}

	private void CheckForInput()
	{
		inputManager.CheckForInput();
	}
}
