﻿using System;
using System.Collections;

namespace IFramework.Modules.Coroutine
{
    /// <summary>
    /// 等待条件不成立
    /// </summary>
    public class WaitWhile : CoroutineInstruction
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="condition">等待不成立条件</param>
        public WaitWhile(Func<bool> condition)
        {
            Condition = condition;
        }

        private Func<bool> Condition { get; }
        /// <summary>
        /// override
        /// </summary>
        /// <returns></returns>
        protected override IEnumerator InnerLogoc()
        {
            while (Condition.Invoke())
            {
                yield return false;
            }
            yield return true;
        }
    }
}
