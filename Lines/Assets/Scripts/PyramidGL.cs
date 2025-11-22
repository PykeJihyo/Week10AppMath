using UnityEngine;

public class PyramidGL : GLShapeBase
{
    public float size = 1f;
    public float height = 1f;
    public Color color = Color.cyan;

    void OnRenderObject()
    {
        BeginGL(color);

        float s = size * 0.5f;
        Vector3[] baseVerts = new Vector3[]
        {
            new Vector3(-s, 0, -s),
            new Vector3(s, 0, -s),
            new Vector3(s, 0, s),
            new Vector3(-s, 0, s)
        };
        Vector3 top = new Vector3(0, height, 0);

        // base (two triangles)
        GL.Begin(GL.TRIANGLES);
        GL.Color(color * 0.9f);
        GL.Vertex(baseVerts[0]);
        GL.Vertex(baseVerts[1]);
        GL.Vertex(baseVerts[2]);

        GL.Vertex(baseVerts[2]);
        GL.Vertex(baseVerts[3]);
        GL.Vertex(baseVerts[0]);
        GL.End();

        // four side triangles
        GL.Begin(GL.TRIANGLES);
        GL.Color(color);
        for (int i = 0; i < 4; i++)
        {
            int n = (i + 1) % 4;
            GL.Vertex(top);
            GL.Vertex(baseVerts[i]);
            GL.Vertex(baseVerts[n]);
        }
        GL.End();

        EndGL();
    }
}