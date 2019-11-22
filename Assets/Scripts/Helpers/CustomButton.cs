using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Helpers
{
    public class CustomButton : Button
    {
        public event Action OnHeldDown = () => { };

        private bool isPointerDown = false;
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            isPointerDown = true;
        }
        
        public override void OnPointerUp(PointerEventData eventData)
                {
                    base.OnPointerDown(eventData);
                    isPointerDown = false;
                }

        private void Update()
        {
            if (isPointerDown)
            {
                OnHeldDown();
            }
        }
    }
}