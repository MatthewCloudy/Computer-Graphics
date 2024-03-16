using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace p4
{
    internal class Sphere
    {
        public List<Triangle> triangles;
        public Vector3 center = new Vector3(0,0,0);

        public Sphere(int latitudeSegments, int longitudeSegments, float radius)
        {
            triangles = new List<Triangle>();

            for (int lat = 0; lat < latitudeSegments; lat++)
            {
                for (int lon = 0; lon < longitudeSegments; lon++)
                {
                    int current = lat * (longitudeSegments + 1) + lon;
                    int next = current + longitudeSegments + 1;

                    Vector3 v1 = GetPosition(lat, lon, latitudeSegments, longitudeSegments, radius);
                    Vector3 v2 = GetPosition(lat + 1, lon, latitudeSegments, longitudeSegments, radius);
                    Vector3 v3 = GetPosition(lat, lon + 1, latitudeSegments, longitudeSegments, radius);
                    Vector3 n1 = Vector3.Normalize(v1 - center);
                    Vector3 n2 = Vector3.Normalize(v2 - center);
                    Vector3 n3 = Vector3.Normalize(v3 - center);
                    triangles.Add(new Triangle(v1, v2, v3, n1, n2, n3));

                    v1 = GetPosition(lat, lon + 1, latitudeSegments, longitudeSegments, radius);
                    v2 = GetPosition(lat + 1, lon, latitudeSegments, longitudeSegments, radius);
                    v3 = GetPosition(lat + 1, lon + 1, latitudeSegments, longitudeSegments, radius);
                    triangles.Add(new Triangle(v1, v2, v3));
                }
            }
        }

        private Vector3 GetPosition(int lat, int lon, int latitudeSegments, int longitudeSegments, float radius)
        {
            float theta = lat * (float)Math.PI / latitudeSegments;
            float phi = lon * 2 * (float)Math.PI / longitudeSegments;

            float x = (float)(radius * Math.Sin(theta) * Math.Cos(phi));
            float y = (float)(radius * Math.Sin(theta) * Math.Sin(phi));
            float z = (float)(radius * Math.Cos(theta));

            return new Vector3(x, y, z);
        }
    }
}
