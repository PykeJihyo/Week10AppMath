using UnityEngine;

public class SphereGL : GLShapeBase
{
    public int latSegments = 12; // >5
    public int lonSegments = 12; // >5
    public float radius = 0.5f;
    public Color color = new Color(0.4f, 0.6f, 1f, 1f);

    void OnRenderObject()
    {
        if (latSegments < 6) latSegments = 6;
        if (lonSegments < 6) lonSegments = 6;
        BeginGL(color);

        GL.Begin(GL.TRIANGLES);
        GL.Color(color);

        for (int lat = 0; lat < latSegments; lat++)
        {
            float a1 = Mathf.PI * (-0.5f + (float)lat / latSegments);
            float a2 = Mathf.PI * (-0.5f + (float)(lat + 1) / latSegments);
            float y1 = Mathf.Sin(a1), cos1 = Mathf.Cos(a1);
            float y2 = Mathf.Sin(a2), cos2 = Mathf.Cos(a2);

            for (int lon = 0; lon < lonSegments; lon++)
            {
                float b1 = 2f * Mathf.PI * (float)((lon)) / lonSegments;
                float b2 = 2f * Mathf.PI * (float)((lon + 1)) / lonSegments;
                Vector3 p1 = new Vector3(Mathf.Cos(b1) * cos1, y1, Mathf.Sin(b1) * cos1) * radius;
                Vector3 p2 = new Vector3(Mathf.Cos(b2) * cos1, y1, Mathf.Sin(b2) * cos1) * radius;
                Vector3 p3 = new Vector3(Mathf.Cos(b1) * cos2, y2, Mathf.Sin(b1) * cos2) * radius;
                Vector3 p4 = new Vector3(Mathf.Cos(b2) * cos2, y2, Mathf.Sin(b2) * cos2) * radius;

                // two triangles for quad
                GL.Vertex(p1);
                GL.Vertex(p3);
                GL.Vertex(p2);

                GL.Vertex(p2);
                GL.Vertex(p3);
                GL.Vertex(p4);
            }
        }

        GL.End();
        EndGL();
    }
}