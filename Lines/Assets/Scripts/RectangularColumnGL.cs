using UnityEngine;

public class RectangularColumnGL : GLShapeBase
{
    public Vector3 size = new Vector3(1f, 2f, 0.5f);
    public Color color = new Color(0.5f, 0.8f, 0.5f, 1f);

    void OnRenderObject()
    {
        BeginGL(color);
        Vector3 h = size * 0.5f;
        Vector3[] v = new Vector3[8]
        {
            new Vector3(-h.x, -h.y, -h.z),
            new Vector3(h.x, -h.y, -h.z),
            new Vector3(h.x, -h.y, h.z),
            new Vector3(-h.x, -h.y, h.z),
            new Vector3(-h.x, h.y, -h.z),
            new Vector3(h.x, h.y, -h.z),
            new Vector3(h.x, h.y, h.z),
            new Vector3(-h.x, h.y, h.z)
        };

        int[][] faces = new int[][]
        {
            new int[]{0,1,2,3}, // bottom
            new int[]{4,5,6,7}, // top
            new int[]{0,1,5,4}, // front
            new int[]{1,2,6,5}, // right
            new int[]{2,3,7,6}, // back
            new int[]{3,0,4,7}  // left
        };

        GL.Begin(GL.TRIANGLES);
        GL.Color(color);
        foreach (var f in faces)
        {
            // two triangles
            GL.Vertex(v[f[0]]);
            GL.Vertex(v[f[1]]);
            GL.Vertex(v[f[2]]);

            GL.Vertex(v[f[2]]);
            GL.Vertex(v[f[3]]);
            GL.Vertex(v[f[0]]);
        }
        GL.End();

        EndGL();
    }
}