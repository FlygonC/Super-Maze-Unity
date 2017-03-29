using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))][RequireComponent(typeof(MeshRenderer))][ExecuteInEditMode]
public class BlockRenderer : MonoBehaviour {

    private BlockBase block;
    private MeshFilter filter;
    private MeshRenderer render;
    public Material material;

    Mesh mesh;
    //[SerializeField]
    Vector3[] vertices = new Vector3[4];
    //[SerializeField]
    int[] tri = new int[6];
    //[SerializeField]
    //Vector3[] normals = new Vector3[4];
    //[SerializeField]
    Vector2[] uv = new Vector2[4];

    // Use this for initialization
    void Start ()
    {
        block = GetComponent<BlockBase>();
        filter = GetComponent<MeshFilter>();
        render = GetComponent<MeshRenderer>();

        render.material = material;

        mesh = new Mesh();
        filter.mesh = mesh;

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(block.width, 0, 0);
        vertices[2] = new Vector3(0, block.height, 0);
        vertices[3] = new Vector3(block.width, block.height, 0);

        mesh.vertices = vertices;

        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 1;

        tri[3] = 2;
        tri[4] = 3;
        tri[5] = 1;

        mesh.triangles = tri;

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(block.width, 0);
        uv[2] = new Vector2(0, block.height);
        uv[3] = new Vector2(block.width, block.height);

        mesh.uv = uv;

    }

    void Update()
    {

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(block.width, 0, 0);
        vertices[2] = new Vector3(0, block.height, 0);
        vertices[3] = new Vector3(block.width, block.height, 0);

        mesh.vertices = vertices;

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(block.width, 0);
        uv[2] = new Vector2(0, block.height);
        uv[3] = new Vector2(block.width, block.height);

        mesh.uv = uv;

    }

}
