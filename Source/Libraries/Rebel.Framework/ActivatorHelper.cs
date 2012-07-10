﻿using System;

namespace Rebel.Framework
{
    /// <summary>
    /// Helper methods for Activation
    /// </summary>
    public static class ActivatorHelper
    {
        /// <summary>
        /// Creates an instance of a type using that type's default constructor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateInstance<T>() where T : class, new()
        {
            return Activator.CreateInstance(typeof (T)) as T;
        }
    }
}
