using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
        [SerializeField] private LayerMask layerMask;
        private Mesh mesh;
        private Vector3 origin;

        public Vector3 GetVectorFromAngle(float angle)
        {
                float angleRad = angle * (Mathf.PI / 180f);
                return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }

        private void Start()
        { 
                mesh = new Mesh();
                GetComponent<MeshFilter>().mesh = mesh;
                origin = Vector3.zero;
        }

        private void LateUpdate()
        {
                float fov = 90f;
                int rayCount = 50;
                float angle = 0f;
                float angleIncrease = fov / rayCount;
                float viewDistnace = 50f;

                Vector3[] verticles = new Vector3[rayCount + 2];
                Vector2[] uv = new Vector2[verticles.Length];
                int[] triangles = new int[rayCount * 3];

                verticles[0] = origin;


                int vertexIndex = 1;
                int triangleIndex = 0;
                for (int i = 0; i <= rayCount; i++)
                {
                        Vector3 vertex;
                        RaycastHit2D rayCastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistnace, layerMask);

                        if (rayCastHit2D.collider == null)
                        {
                                vertex = origin + GetVectorFromAngle(angle) * viewDistnace;
                        }
                        else
                        {
                                vertex = rayCastHit2D.point;
                        }
                                       

                        verticles[vertexIndex] = vertex;

                        if (i > 0)
                        {
                                triangles[triangleIndex + 0] = 0;
                                triangles[triangleIndex + 1] = vertexIndex - 1;
                                triangles[triangleIndex + 2] = vertexIndex;

                                triangleIndex += 3;
                        }
                        vertexIndex++;
                        angle -= angleIncrease;
                }

                mesh.vertices = verticles;
                mesh.uv = uv;
                mesh.triangles = triangles;
        }

        public void SetOrigin(Vector3 origin)
        {
                this.origin = origin;   
        }
}