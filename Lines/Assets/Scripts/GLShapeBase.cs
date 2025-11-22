using UnityEngine;

public class GLShapeBase : MonoBehaviour
{
    protected static Material s_glMaterial;

    protected virtual void CreateMaterialIfNeeded()
    {
        if (s_glMaterial != null) return;

        Shader shader = Shader.Find("Hidden/Internal-Colo red");
        if (shader == null)
            shader = Shader.Find("Hidden/Internal-Colored");

        s_glMaterial = new Material(shader);
        s_glMaterial.hideFlags = HideFlags.HideAndDontSave;
        s_glMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        s_glMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        s_glMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
        s_glMaterial.SetInt("_ZWrite", 1);
    }

    protected void BeginGL(Color col)
    {
        CreateMaterialIfNeeded();
        s_glMaterial.SetPass(0);
        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);
        GL.Color(col);
    }

    protected void EndGL()
    {
        GL.PopMatrix();
    }
}