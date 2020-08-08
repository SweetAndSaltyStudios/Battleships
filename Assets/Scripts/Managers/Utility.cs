using System.Collections.Generic;
using UnityEngine;

namespace SweetAndSaltyStudios
{
    public static class Utility
    {
        public static IList<T> CreateBehaviours<T>(string name, T prefab, Transform parent = null, int amount = 1) where T : Behaviour
        {
            if(prefab == null) { Debug.LogWarning($"'{typeof(T)}' prefab is NULL"); return null; }

            var newBehaviours = new T[amount];

            for(int i = 0; i < amount; i++)
            {
                newBehaviours[i] = CreateBehaviour($"{name} {i + 1}", prefab, parent);
            }

            return newBehaviours;
        }

        public static T CreateBehaviour<T>(string name, T prefab, Transform parent = null) where T : Behaviour
        {
            if(prefab == null) { Debug.LogWarning($"'{typeof(T)}' prefab is NULL"); return null; }

            var newBehaviour = Object.Instantiate(prefab, parent);
            newBehaviour.name = name;
            return newBehaviour;
        }
    }
}