using MyCompany.GameFramework.InputManagement.Interfaces;
using UnityEngine;

namespace MyCompany.GameFramework.InputManagement
{
	public class RadialMouseInputHandler : IMouseInputHandler 
	{
		public Vector2 GetRawPosition()
		{
			return Input.mousePosition;
		}

		public Vector2 GetInput()
		{
			Vector2 mousePos = GetRawPosition();
			Vector2 relativeMousePos = new Vector2(mousePos.x - Screen.width/2, mousePos.y - Screen.height/2);
			float angle = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * Mathf.Rad2Deg * -1;
			Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
			return rot.eulerAngles;
		}
	}
}
