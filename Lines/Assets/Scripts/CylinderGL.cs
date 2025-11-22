using UnityEngine;

public class CylinderGL : GLShapeBase
{
    public int segments = 24; // set > 5
    public float radius = 0.5f;
    public float height = 1f;
    public Color color = new Color(0.9f, 0.6f, 0.2f, 1f);

    void OnRenderObject()
    {
        if (segments < 6) segments = 6;
        BeginGL(color);

        float half = height * 0.5f;
        // compute circle points
        Vector3[] pts = new Vector3[segments];
        for (int i = 0; i < segments; i++)
        {
            float a = (i / (float)segments) * Mathf.PI * 2f;
            pts[i] = new Vector3(Mathf.Cos(a) * radius, -half, Mathf.Sin(a) * radius);
        }

        // top and bottom caps (triangles fan)
        GL.Begin(GL.TRIANGLES);
        GL.Color(color * 0.9f);
        Vector3 topCenter = new Vector3(0, half, 0);
        for (int i = 0; i < segments; i++)
        {
            int n = (i + 1) % segments;
            // top cap
            GL.Vertex(topCenter);
            GL.Vertex(new Vector3(pts[n].x, half, pts[n].z));
            GL.Vertex(new Vector3(pts[i].x, half, pts[i].z));
            // bottom cap
            GL.Vertex(new Vector3(pts[i].x, -half, pts[i].z));
            GL.Vertex(new Vector3(pts[n].x, -half, pts[n].z));
            GL.Vertex(new Vector3(0, -half, 0));
        }
        GL.End();

        // sides (two triangles per segment)
        GL.Begin(GL.TRIANGLES);
        GL.Color(color);
        for (int i = 0; i < segments; i++)
        {
            int n = (i + 1) % segments;
            Vector3 a1 = new Vector3(pts[i].x, -half, pts[i].z);
            Vector3 a2 = new Vector3(pts[n].x, -half, pts[n].z);
            Vector3 b1 = new Vector3(pts[i].x, half, pts[i].z);
            Vector3 b2 = new Vector3(pts[n].x, half, pts[n].z);

            // triangle 1
            GL.Vertex(a1);
            GL.Vertex(b1);
            GL.Vertex(b2);
            // triangle 2
            GL.Vertex(a1);
            GL.Vertex(b2);
            GL.Vertex(a2);
        }
        GL.End();

        EndGL();
    }
}