using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Helpers
{
    public class RotationButton : Button
    {public event Action OnHeldDown = () => { };

        private bool isPointerDown = false;

        public void SetArrowVisible(bool isVisible)
        {
            //Move to field
            GetComponentInChildren<Image>().enabled = isVisible;
        }

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

        protected override void OnDisable()
        {
            base.OnDisable();
            if (isPointerDown) isPointerDown = false;
        }
    }
}