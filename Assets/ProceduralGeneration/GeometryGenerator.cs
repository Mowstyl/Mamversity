using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]

public class GeometryGenerator : MonoBehaviour {
	// Use this for initialization
	Mesh mesh;
	int[] triangles;
	Vector3[] vertices;
	//Renderer rend = GetComponent<Renderer>();
	Vector2[] centroids;
	public GameObject obj;
	Vector3 trans=new Vector3(10,0,5);

	void Awake(){
		Random.seed = 42;
		//Random.value; between 0,1
		mesh = GetComponent<MeshFilter> ().mesh;
	}


	void Start () {
		//MakeBuilding (0, 20, 0, 10, (float)0.0);
		//LocateBuilding (new Vector3 (10, 0, 5), new Vector3 (0, 0, 0), mesh);
		//transform.position =trans;

	}

	void MakeMesh(){
		vertices = new Vector3[]{new Vector3(0,0,0),new Vector3(0,0,1),new Vector3(1,0,0) };
		triangles = new int[]{0,1,2 };
		mesh.Clear ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;

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

	void MakeCity(float xMin, float xMax, float yMin, float yMax){
			
	}

	void LocateBuilding(Vector3 pos, Vector3 rot, Mesh building){
		//Vector3 trans = pos-mesh.vertices [0];
		for(int i=0;i<mesh.vertices.Length;i++){
			mesh.vertices [i] = mesh.vertices [i] + trans;
		}
	}












	void Kmeans(Vector2[] cloudPoints, int nCentroids, Vector2 leftBottonPoint, Vector2 rightTopPoint){
		for(int i =0;i<nCentroids;i++){
			centroids [i] = new Vector2 ((((rightTopPoint.x-leftBottonPoint.x)*Random.value)+leftBottonPoint.x),(((rightTopPoint.y-leftBottonPoint.y)*Random.value)+leftBottonPoint.y));
		}


	}

	/*vector<int> CImagen::kmeans(vector<int> pixels) {
		//z = sizeof(pixels);
		vector<int> centroidsRepeated(pixels.size());
		vector<int> clusterP (pixels.size());
		vector<int> clusterPnew (pixels.size());
		vector<int> visited(0);
		int k = (int)sqrt(pixels.size()) / 2;
		vector<int> centroids(k);
		int contador = 0;
		//generamos centroides de los pixeles existentes
		int fila, col,p;
		fila = col = 0;
		for (int i = 0; i<k; i++) {


			double r = ((double)rand() / (RAND_MAX));
			p = r*(pixels.size() - 1);
			if (!inVector(p, visited)) { centroids[i] = pixels[p]; visited.push_back(p);}
			else { i--; }


		}
		//inicializamos el cluster al que pertenecen los pixels
		for (int i = 0; i < pixels.size();i++) {
			clusterP[i] = 0;
			clusterPnew[i] = centroidPixel(centroids, pixels[i]);
		}


		while (changed(clusterP,clusterPnew)&& contador<pixels.size()) {
			//for (int h = 0; h < 70;h++) {
			centroids = updateCentroids(centroids, pixels, clusterPnew);
			for (int i = 0; i < pixels.size(); i++) {
				clusterP[i] = clusterPnew[i];
			}
			for (int i = 0; i < pixels.size(); i++) {
				clusterPnew[i] = centroidPixel(centroids, pixels[i]);
			}
			centroids = updateCentroids(centroids,pixels,clusterPnew);
			centroidsRepeated.resize(repeatedCentroids(centroids).size());
			centroidsRepeated = repeatedCentroids(centroids);
			contador++;
		}

		return centroids;
	}*/



}
