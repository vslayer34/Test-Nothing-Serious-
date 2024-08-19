using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class ArrayMeshExample : MeshInstance3D
{
	private int _rings = 50;
	private int _radialSegments = 50;
	private float _radius = 1.0f;



	// Game Loop Methods---------------------------------------------------------------------------
    public override void _Ready()
	{
		// This will be the array that we keep our surface information in - it will hold all the arrays of data that the surface needs.
		// Godot will expect it to be of size Mesh.ARRAY_MAX, so resize it accordingly.
        var surfaceArray = new Godot.Collections.Array();

		surfaceArray.Resize((int)Mesh.ArrayType.Max);

		// Next create the arrays for each data type you will use.
		List<Vector3> vertics = new List<Vector3>();
		List<Vector2> UVs = new List<Vector2>();
		List<Vector3> normals = new List<Vector3>();
		List<int> indices = new List<int>();


		/***********************************
        * Insert code here to generate mesh.
        * *********************************/

		// vertics indices
		int thisRow = 0;
		int prevRow = 0;
		int point = 0;


		// Loop over rings
		for (int i = 0; i < _rings + 1; i++)
		{
			var v = ((float)i) / _rings;
			var w = Mathf.Sin(Mathf.Pi * v);
			var y = Mathf.Cos(Mathf.Pi * v);

			// Loop over segments in ring.
			for (int j = 0; j < _radialSegments + 1; j++)
			{
				var u = ((float)j) / _radialSegments;
				var x = Mathf.Sin(u * Mathf.Pi * 2);
				var z = Mathf.Cos(u * Mathf.Pi * 2);

				Vector3 vert = new Vector3(x * _radialSegments * w, y * _radius, z * _radius * w);
				
				vertics.Add(vert);
				normals.Add(vert.Normalized());
				UVs.Add(new Vector2(u, v));
				point += 1;

				// Create triangles in the rings using indices
				if (i > 0 && j > 0)
				{
					indices.Add(prevRow + j - 1);
					indices.Add(prevRow + j);
					indices.Add(thisRow + j - 1);

					indices.Add(prevRow + j);
					indices.Add(thisRow + j);
					indices.Add(thisRow + j - 1);
				}
			}

			prevRow = thisRow;
			thisRow = point;
		}

		// **************************************************************************************

		// Once you have filled your data arrays with your geometry you can create a mesh by adding each array to surface_array and then committing to the mesh.
		surfaceArray[(int)Mesh.ArrayType.Vertex] = vertics.ToArray();
		surfaceArray[(int)Mesh.ArrayType.TexUV] = UVs.ToArray();
		surfaceArray[(int)Mesh.ArrayType.Normal] = normals.ToArray();
		surfaceArray[(int)Mesh.ArrayType.Index] = indices.ToArray();

		var arrMesh = Mesh as ArrayMesh;

		if (arrMesh != null)
		{
			// Create mesh surface from mesh array
			// No blendshapes, lods, or compression used.
			arrMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, surfaceArray);
		}


		// Saves mesh to a .tres file with compression enabled.
		ResourceSaver.Save(Mesh, "res://sphere.tres", ResourceSaver.SaverFlags.Compress);
    }
}