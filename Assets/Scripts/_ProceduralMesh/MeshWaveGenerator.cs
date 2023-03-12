using UnityEngine;

namespace UGA.Assets.Scripts._ProceduralMesh
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class MeshWaveGenerator : MonoBehaviour
    {
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private float _speed;

        private Vector3[] _verticies;

        private void Update()
        {
            UpdateMesh();
        }

        private void UpdateMesh()
        {
            _verticies = _meshFilter.mesh.vertices;

            for (int i = 0; i < _verticies.Length; i++)
            {
                _verticies[i].z = Mathf.Cos((_verticies[i].x + Time.time * _speed));
            }

            _meshFilter.mesh.vertices = _verticies;
        }
    }
}
