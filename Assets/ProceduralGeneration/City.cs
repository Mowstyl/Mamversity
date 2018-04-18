using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrainyBeard.Tools.Generic;
using BrainyBeard.Procedural.Building.Unity;


public class City : MonoBehaviour {
	public List<GameObject> buildings=new List<GameObject>();
	public List<Vector3> centers=new List<Vector3>();

	public GameObject[] seed;
    public float scale = 1;
	public Generator hola;
	// Use this for initialization
	void Start () {
		Random.InitState (142);
		//buildings.Add ();
		Vector3 [] a=new Vector3[4];
		/*a [0] = centers.ToArray () [0];
		a [1] = centers.ToArray () [1];
		a [2] = centers.ToArray () [2];*/
		a [0] = new Vector3(5,0,4);
		a [1] = new Vector3(1,0,4);
		a [2] = new Vector3(1,0,2);
		a [3] = new Vector3(5,0,2);

	

		/*for (int i = 0; i < centers.Count; i++) {
			GameObject building = new GameObject ();
			building.name = "building_" + i;
			building.AddComponent<MeshRenderer> ();
			building.AddComponent<MeshFilter> ();
			building.GetComponent<MeshFilter> ().mesh = MakeBuildingByVertex(a);//MakeBuilding (0, 20, 0, 10, (float)0.0);
			building.transform.position=centers.ToArray()[i];
			buildings.Add (building);
		}*/


		for (int i = 0; i < centers.Count; i++){
			GameObject building = new GameObject ();
			building.name = "building_" + i;
			//building.AddComponent<MeshRenderer> ();
			//building.AddComponent<MeshFilter> ();
			//building.AddComponent<Generator> ();
			building.transform.position=centers.ToArray()[i];
		}

		//GameObject Building = Instantiate(seed[Random.Range(0, seed.Length)], transform.position, transform.rotation);
        //Building.transform.localScale = new Vector3(scale, scale, scale);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	Mesh MakeBuilding(float xMin, float xMax, float zMin, float zMax, float drunk){
		Mesh meshA = new Mesh();
		int[] triangles;
		Vector3[] vertices;

		float height = 40;//20+ Random.value * 200;
		float xDistance = xMax - xMin;
		float step = height / 30;
		float xMinNew,xMaxNew,zMinNew,zMaxNew;
		zMinNew = zMin;
		zMaxNew = zMax;
		float zDistance = zMax - zMin;
		float y, z;
		y=z = 0;
		List<Vector3> vertex = new List<Vector3> ();
		List<int> tri = new List<int> ();
		vertex.Add (new Vector3 (xMin, y, zMin));
		vertex.Add (new Vector3(xMin+xDistance,y,zMin));
		vertex.Add (new Vector3(xMin+xDistance,y,zMax));
		vertex.Add (new Vector3(xMin,y,zMax));
		Vector3 newVertex,newVertex2;
		//Vector3 point=new Vector3(xMin,0,zMin);


		for(int i=1;i<30;i++){
			xMinNew=xMin+drunk*(float)2*Mathf.Sin(30*i*2*Mathf.PI/360);
			xMaxNew = xMinNew + xDistance;
			zMinNew=zMin+drunk*(float)2*Mathf.Cos(30*i*2*Mathf.PI/360);
			zMaxNew = zMinNew + zDistance;
			vertex.Add (new Vector3(xMinNew,y+i*step,zMinNew));

			vertex.Add (new Vector3(xMaxNew,y+i*step,zMinNew));

			vertex.Add (new Vector3(xMaxNew,y+i*step,zMaxNew));

			vertex.Add (new Vector3(xMinNew,y+i*step,zMaxNew));
			//front face
			tri.Add (vertex.Count-8);
			tri.Add (vertex.Count - 7);
			tri.Add (vertex.Count-4);

			tri.Add (vertex.Count-4);
			tri.Add (vertex.Count - 7);
			tri.Add (vertex.Count-8);

			tri.Add (vertex.Count-7);
			tri.Add (vertex.Count - 4);
			tri.Add (vertex.Count-3);

			tri.Add (vertex.Count-3);
			tri.Add (vertex.Count - 4);
			tri.Add (vertex.Count-7);
			//rigth side face
			tri.Add (vertex.Count-7);
			tri.Add (vertex.Count - 6);
			tri.Add (vertex.Count-3);

			tri.Add (vertex.Count-3);
			tri.Add (vertex.Count - 6);
			tri.Add (vertex.Count-7);

			tri.Add (vertex.Count-2);
			tri.Add (vertex.Count - 3);
			tri.Add (vertex.Count-6);

			tri.Add (vertex.Count-6);
			tri.Add (vertex.Count - 3);
			tri.Add (vertex.Count-2);
			//back face
			tri.Add (vertex.Count-6);
			tri.Add (vertex.Count - 5);
			tri.Add (vertex.Count-2);

			tri.Add (vertex.Count-2);
			tri.Add (vertex.Count - 5);
			tri.Add (vertex.Count-6);

			tri.Add (vertex.Count-5);
			tri.Add (vertex.Count - 1);
			tri.Add (vertex.Count-2);

			tri.Add (vertex.Count-2);
			tri.Add (vertex.Count - 1);
			tri.Add (vertex.Count-5);
			//left side face
			tri.Add (vertex.Count-8);
			tri.Add (vertex.Count - 5);
			tri.Add (vertex.Count-4);

			tri.Add (vertex.Count-4);
			tri.Add (vertex.Count - 5);
			tri.Add (vertex.Count-8);

			tri.Add (vertex.Count-5);
			tri.Add (vertex.Count - 1);
			tri.Add (vertex.Count-4);

			tri.Add (vertex.Count-4);
			tri.Add (vertex.Count - 1);
			tri.Add (vertex.Count-5);

		}
		tri.Add (vertex.Count-1);
		tri.Add (vertex.Count - 2);
		tri.Add (vertex.Count-3);

		tri.Add (vertex.Count-3);
		tri.Add (vertex.Count - 2);
		tri.Add (vertex.Count-1);

		tri.Add (vertex.Count-3);
		tri.Add (vertex.Count - 4);
		tri.Add (vertex.Count-1);

		meshA.Clear ();
		meshA.vertices = vertex.ToArray();
		meshA.triangles = tri.ToArray();
		meshA.RecalculateNormals();

		return meshA;

	}
	Mesh LocateBuilding(Vector3 pos, Vector3 rot, Mesh building){
		//Vector3 trans = pos-mesh.vertices [0];
		for(int i=0;i<building.vertices.Length;i++){
			building.vertices [i] = building.vertices [i] + pos;
		}
		return building;
	}


	Mesh MakeBuildingByVertex(Vector3[] mainVertices){
		Mesh meshA = new Mesh();
		int[] triangles;
		Vector3[] vertices;

		float height = 40;//20+ Random.value * 200;

		float step = height / 30;

		float y, z;
		y=z = 0;
		List<Vector3> vertex = new List<Vector3> ();
		List<int> tri = new List<int> ();

		//Vector3 point=new Vector3(xMin,0,zMin);

		for(int i=0;i<mainVertices.Length;i++){
			vertex.Add (mainVertices[i]);

			/*
			tri.Add (vertex.Count-1);
			tri.Add (vertex.Count - mainVertices.GetLength()-1);
			tri.Add (vertex.Count - mainVertices.GetLength());*/

		}
		for(int i=1;i<10;i++){
			for(int k=0;k<mainVertices.Length-1;k++){
				vertex.Add (new Vector3(mainVertices[k].x,y+i*step,mainVertices[k].z));
				tri.Add (vertex.Count-1);
				tri.Add (vertex.Count - mainVertices.Length-1);
				tri.Add (vertex.Count - mainVertices.Length);

				tri.Add (vertex.Count-1);
				tri.Add (vertex.Count - mainVertices.Length);
				tri.Add (vertex.Count - mainVertices.Length-1);

			}
			vertex.Add (new Vector3(mainVertices[mainVertices.Length-1].x,y+i*step,mainVertices[mainVertices.Length-1].z));
			tri.Add (vertex.Count-1);
			tri.Add (vertex.Count - mainVertices.Length-1);
			tri.Add (vertex.Count - mainVertices.Length*2);

			tri.Add (vertex.Count-1);
			tri.Add (vertex.Count - mainVertices.Length*2);
			tri.Add (vertex.Count - mainVertices.Length-1);

			/*
			for(int j=1;j<mainVertices.GetLength();j++){


			}*/

		}



		/*for(int i=1;i<30;i++){
			xMinNew=xMin+drunk*(float)2*Mathf.Sin(30*i*2*Mathf.PI/360);
			xMaxNew = xMinNew + xDistance;
			zMinNew=zMin+drunk*(float)2*Mathf.Cos(30*i*2*Mathf.PI/360);
			zMaxNew = zMinNew + zDistance;
			vertex.Add (new Vector3(xMinNew,y+i*step,zMinNew));

			vertex.Add (new Vector3(xMaxNew,y+i*step,zMinNew));

			vertex.Add (new Vector3(xMaxNew,y+i*step,zMaxNew));

			vertex.Add (new Vector3(xMinNew,y+i*step,zMaxNew));
			//front face
			tri.Add (vertex.Count-8);
			tri.Add (vertex.Count - 7);
			tri.Add (vertex.Count-4);

			tri.Add (vertex.Count-4);
			tri.Add (vertex.Count - 7);
			tri.Add (vertex.Count-8);

			tri.Add (vertex.Count-7);
			tri.Add (vertex.Count - 4);
			tri.Add (vertex.Count-3);

			tri.Add (vertex.Count-3);
			tri.Add (vertex.Count - 4);
			tri.Add (vertex.Count-7);
			//rigth side face
			tri.Add (vertex.Count-7);
			tri.Add (vertex.Count - 6);
			tri.Add (vertex.Count-3);

			tri.Add (vertex.Count-3);
			tri.Add (vertex.Count - 6);
			tri.Add (vertex.Count-7);

			tri.Add (vertex.Count-2);
			tri.Add (vertex.Count - 3);
			tri.Add (vertex.Count-6);

			tri.Add (vertex.Count-6);
			tri.Add (vertex.Count - 3);
			tri.Add (vertex.Count-2);
			//back face
			tri.Add (vertex.Count-6);
			tri.Add (vertex.Count - 5);
			tri.Add (vertex.Count-2);

			tri.Add (vertex.Count-2);
			tri.Add (vertex.Count - 5);
			tri.Add (vertex.Count-6);

			tri.Add (vertex.Count-5);
			tri.Add (vertex.Count - 1);
			tri.Add (vertex.Count-2);

			tri.Add (vertex.Count-2);
			tri.Add (vertex.Count - 1);
			tri.Add (vertex.Count-5);
			//left side face
			tri.Add (vertex.Count-8);
			tri.Add (vertex.Count - 5);
			tri.Add (vertex.Count-4);

			tri.Add (vertex.Count-4);
			tri.Add (vertex.Count - 5);
			tri.Add (vertex.Count-8);

			tri.Add (vertex.Count-5);
			tri.Add (vertex.Count - 1);
			tri.Add (vertex.Count-4);

			tri.Add (vertex.Count-4);
			tri.Add (vertex.Count - 1);
			tri.Add (vertex.Count-5);

		}
		tri.Add (vertex.Count-1);
		tri.Add (vertex.Count - 2);
		tri.Add (vertex.Count-3);

		tri.Add (vertex.Count-3);
		tri.Add (vertex.Count - 2);
		tri.Add (vertex.Count-1);

		tri.Add (vertex.Count-3);
		tri.Add (vertex.Count - 4);
		tri.Add (vertex.Count-1);
*/
		meshA.Clear ();
		meshA.vertices = vertex.ToArray();
		meshA.triangles = tri.ToArray();
		meshA.RecalculateNormals();

		return meshA;

	}


}
