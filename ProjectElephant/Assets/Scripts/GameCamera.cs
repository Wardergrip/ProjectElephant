using System;
using UnityEngine;

namespace Elephant
{
    public class GameCamera : MonoBehaviour
    {
        public static GameCamera Active;

        [SerializeField] private Vector3 _followOffset;

        [NonSerialized] public Transform ToFollow;

        private void OnEnable()
        {
            if (Active != null)
            {
                Debug.LogError($"[GameCamera] Multiple trying to be active!");
                gameObject.SetActive(false);
                return;
            }

            Active = this;
        }

        private void OnDisable()
        {
            Active = null;
        }

        private void Update()
        {
            if (ToFollow == null) return;

            transform.position = ToFollow.position + _followOffset;
        }
    }
}