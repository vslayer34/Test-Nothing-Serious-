using Godot;
using System;

public partial class ImmediateMeshExample : Node
{
    public override void _Ready()
    {        
		var mesh = new ImmediateMesh();

		// Begin draw
        mesh.SurfaceBegin(Mesh.PrimitiveType.Triangles);

        // Prepare attributes for add_vertex.
        mesh.SurfaceSetNormal(new Vector3(0.0f, 0.0f, 1.0f));
        mesh.SurfaceSetUV(new Vector2(0.0f, 0.0f));

        // Call last for each vertex, adds the above attributes.
        mesh.SurfaceAddVertex(new Vector3(-1.0f, -1.0f, 0.0f));

        mesh.SurfaceSetNormal(new Vector3(0.0f, 0.0f, 1.0f));
        mesh.SurfaceSetUV(new Vector2(0.0f, 0.0f));
        mesh.SurfaceAddVertex(new Vector3(-1.0f, 1.0f, 0.0f));

        mesh.SurfaceSetNormal(new Vector3(0.0f, 0.0f, 1.0f));
        mesh.SurfaceSetUV(new Vector2(0.0f, 0.0f));
        mesh.SurfaceAddVertex(new Vector3(1.0f, 1.0f, 0.0f));

        // End drawing.
        mesh.SurfaceEnd();
    }
}
