using UnityEngine;


namespace SimpleMan.Extensions.Demo
{
    public class DemoScript : MonoBehaviour
    {
        public bool isPressed = false;


        private void Start()
        {
            //Wait until is pressed will be true
            //then invoke OnDone
            this.WaitUntil(() => isPressed == false, OnDone, 0.5f);
        }


        private void OnDone()
        {
            print("OperationDone!");
        }

    }
}
