using System.Collections;
using UnityEngine;

namespace _Root.CleanCode.Room.Infrastructure
{
    public class Fog : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private Coroutine _fogCoroutine;

        public void DisableFog()
        {
            if (_fogCoroutine != null)
            {
                StopCoroutine(_fogCoroutine);
            }

            _fogCoroutine = StartCoroutine(DisableFogRoutine());
        }

        public void EnableFog()
        {
            if (_fogCoroutine != null)
            {
                StopCoroutine(_fogCoroutine);
            }
            _fogCoroutine = StartCoroutine(EnableFogRoutine());
        }

        private IEnumerator EnableFogRoutine()
        {
            var deltaTime = Time.deltaTime;
            var color = _spriteRenderer.color;
            for (float i = 0; i < 1; i+= deltaTime)
            {
                color.a = i;
                _spriteRenderer.color = color;
                yield return null;
            }
            color.a = 1;
            _spriteRenderer.color = color;
        }

        private IEnumerator DisableFogRoutine()
        {
            var deltaTime = Time.deltaTime;
            var color = _spriteRenderer.color;
            for (float i = 1; i < 0; i-= deltaTime)
            {
                color.a = i;
                _spriteRenderer.color = color;
                yield return null;
            }
            color.a = 0;
            _spriteRenderer.color = color;
        }
    }
}