using P504.Promises;
using System;

namespace P504.Promises
{
    public interface ITimers
    {
        IPromise WaitOneFrame();
        IPromise Wait(float seconds, Action<float> progressCallback = null);
        IPromise WaitUnscaled(float seconds, Action<float> progressCallback = null);
        IPromise WaitForTrue(Func<bool> condition);
        void WaitForMainThread(Action action);
    }
}
