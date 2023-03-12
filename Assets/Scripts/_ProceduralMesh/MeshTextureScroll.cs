using UnityEngine;

namespace UGA.Assets.Scripts._ProceduralMesh
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class MeshTextureScroll : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] float _speed;

        void Update()
        {
            _meshRenderer.material.SetTextureOffset("_MainTex", new Vector2(Time.time * _speed, 0));
        }
    }
}


