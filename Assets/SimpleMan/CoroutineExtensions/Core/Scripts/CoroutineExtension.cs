using System;
using System.Collections;
using UnityEngine;


namespace SimpleMan.Extensions
{
    public static class ComponentExtension
    {
        #region DELAY
        public static Coroutine Delay(this MonoBehaviour component, float time, Action callback)
        {
            if(time <= 0)
                throw new ArgumentOutOfRangeException("time argument must be greater than 0");


            return component.StartCoroutine(DelayCounter(time, callback));
        }


        private static IEnumerator DelayCounter(float _time, Action _callback)
        {
            yield return new WaitForSeconds(_time);
            _callback?.Invoke();
        }
        #endregion


        #region WAIT UNTIL
        public static Coroutine WaitUntil(this MonoBehaviour component, Func<bool> condition, Action callback, float delay = 0)
        {
            if(delay <= 0)
                throw new ArgumentOutOfRangeException("delay argument must be greater than 0");


            return component.StartCoroutine(WaitUntilCounter(condition, callback, delay));
        }


        private static IEnumerator WaitUntilCounter(Func<bool> condition, Action callback, float delay = 0)
        {
            while (condition())
            {
                if (delay <= 0)
                    yield return null;

                else
                    yield return new WaitForSeconds(delay);
            }

            callback?.Invoke();
        }
        #endregion


        #region WAIT FRAMES
        public static Coroutine WaitFrames(this MonoBehaviour component, int frames, Action callback)
        {
            if (frames <= 0)
                throw new ArgumentOutOfRangeException("Frames argument must be greater than 0");


            return component.StartCoroutine(WaitFramesCounter(frames, callback));
        }


        private static IEnumerator WaitFramesCounter(int waitFrames, Action callback)
        {
            for (int i = 0; i < waitFrames; i++)
            {
                yield return null;
            }

            callback?.Invoke();
        }
        #endregion


        #region REPEAT UNTIL
        public static Coroutine RepeatForever(this MonoBehaviour component, Action repeatAction, float delay = 0)
        {
            if(delay <= 0)
                throw new ArgumentOutOfRangeException("Frames argument must be greater than 0");


            return component.StartCoroutine(RepeatUntilCounter(() => true, repeatAction, null, delay));
        }


        public static Coroutine RepeatUntil(this MonoBehaviour component, Func<bool> condition, Action repeatAction, Action callback, float delay = 0)
        {
            return component.StartCoroutine(RepeatUntilCounter(condition, repeatAction, callback, delay));
        }


        private static IEnumerator RepeatUntilCounter(Func<bool> condition, Action repeatAction, Action callback, float delay = 0)
        {
            while (condition())
            {
                repeatAction?.Invoke();


                if (delay <= 0)
                    yield return null;

                else
                    yield return new WaitForSeconds(delay);
            }

            callback?.Invoke();
        }
        #endregion
    }
}
