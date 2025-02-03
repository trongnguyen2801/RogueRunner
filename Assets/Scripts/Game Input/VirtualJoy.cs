using System;
using DG.Tweening;
using Game_Input;
using Ultils;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoy : MonoBehaviour
{
   private FixedJoystick _joystick;

   private void Awake()
   {
      _joystick = GetComponent<FixedJoystick>();
   }

   private void Update()
   {
      GameInputManager.joystick = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
   }
}
