using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.U2D;
using UnityEngine.U2D.Animation;

namespace UnityEngine.U2D.Animation
{
    class ReSkin : Editor
    {
        [MenuItem("GameObject/Menu/DoAll", false, 0)]
        public static void Full()
        {
            FindMissingScriptsRecursively.FindAndRemoveMissingInSelected();
            var sprites = Selection.activeGameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (var item in sprites)
            {
                Do(item.gameObject);
            }
        }

        [MenuItem("GameObject/Menu/Do Something", false, 0)]
        public static void Do()
        {
            Do(Selection.activeGameObject);
        }
        public static void Do(GameObject target = null)
        {
            if (!target)
            {
                target = Selection.activeGameObject;
            }

            var a = target.GetComponent<SpriteRenderer>();
            if (a.sprite == null)
                return;
            var bones = a.sprite.GetBones();
            if (bones.Length == 0)
            {
                Debug.LogWarning("Нет костей!");
                return;
            }

            Dictionary<string, Transform> reff = new Dictionary<string, Transform>();

            a.transform.FindObjectOfName(ref reff, bones.Select(x => x.name).ToArray());
            if (reff.Count == 0)
            {
                Debug.Log("Нет подходящих элементов");
                return;
            }
            if (a.gameObject.GetComponent<SpriteSkin>())
            {
                Debug.LogWarning("Скелет уже есть");
                return;
            }
            var spriteSkin = a.gameObject.AddComponent<SpriteSkin>();


            spriteSkin.SetBones(reff.Select(x => x.Value).ToArray());
            //spriteSkin.Create();
            Debug.Log("Скелет добавлен!");
        }
        [MenuItem("GameObject/Menu/Check bones", false, 0)]
        public static void Check()
        {
            var a = Selection.activeGameObject.GetComponent<SpriteRenderer>();

            var bones = a.sprite.GetBones();

            Debug.Log("На этом объекте костей " + bones.Length);
            //spriteSkin.Create();
        }

    }
    static class ReSkinExtension
    {
        public static void FindObjectOfName(this Transform parent, ref Dictionary<string, Transform> bones, string[] names)
        {

            if (names.Contains(parent.name) && !bones.ContainsKey(parent.name))
                bones.Add(parent.name, parent.transform);

            if (parent.childCount == 0)
                return;

            foreach (Transform transform in parent)
            {
                transform.FindObjectOfName(ref bones, names);
            }
        }
        public static void Create(this SpriteSkin spriteSkin)
        {
            var Type = typeof(SpriteSkin).Assembly
                .GetTypes()
                .First(x => x.Name == "SpriteSkinUtility");
            Debug.Log(Type.Name);
            Debug.Log(Type.GetMethod("CreateBoneHierarchy", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).Name);
            foreach (var item in Type.GetMethods())
            {
                Debug.Log(item.Name);
            }
            var method = Type.GetMethod("CreateBoneHierarchy",
                System.Reflection.BindingFlags.Static |
                System.Reflection.BindingFlags.NonPublic);

            method.Invoke(null, new object[] { spriteSkin });
        }
        public static void SetBones(this SpriteSkin spriteSkin, Transform[] bones)
        {
            var type = spriteSkin.GetType();

            var rootProperty = type.GetProperty("rootBone");
            var bonesProperty = type.GetProperty("boneTransforms");

            rootProperty.SetValue(spriteSkin, bones.First());
            bonesProperty.SetValue(spriteSkin, bones);
        }
    }
}