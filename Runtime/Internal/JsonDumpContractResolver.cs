using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GameCtor.ULogging
{
    /// <summary>
    /// Resolves all properties and fields of a type, including private ones, 
    /// but excludes those found in MonoBehaviour, Behaviour, Component, and UnityEngine.Object.
    /// </summary>
    internal sealed class JsonDumpContractResolver : DefaultContractResolver
    {
        private static readonly Type[] BlackList = new[] { typeof(MonoBehaviour), typeof(Behaviour), typeof(Component), typeof(UnityEngine.Object) };

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var propertyInfos = type
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(PropertyIsValid)
                .Select(p => CreateProperty(p, memberSerialization));

            var fieldInfos = type
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(FieldIsValid)
                .Select(f => CreateProperty(f, memberSerialization));

            var props = propertyInfos.Union(fieldInfos).ToList();
            props.ForEach(p =>
            {
                p.Writable = false;
                p.Readable = true;
            });

            return props;
        }

        private static bool PropertyIsValid(PropertyInfo propertyInfo) =>
            !BlackList.Contains(propertyInfo.DeclaringType)
            && propertyInfo.GetIndexParameters().Length == 0;

        private static bool FieldIsValid(FieldInfo fieldInfo) =>
            !fieldInfo.IsDefined(typeof(CompilerGeneratedAttribute), false)
            && !fieldInfo.Name.StartsWith("<")
            && !BlackList.Contains(fieldInfo.DeclaringType);
    }
}
