using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generator : MonoBehaviour {

    public GameObject[] seed;
	public float scale = (float)1;
	public List<Vector3> centers=new List<Vector3>();
	public List<Vector3> edges=new List<Vector3>();
	public Vector3 floorMax;
	public Vector3 floorMin;
	public int rot = 0;
	public Material mat2;
	public Material[] materials;
	public Material m_Material;

	public void Start () {
		
        Generate();

	}

	public void Generate () {
		
		GameObject floor = new GameObject ();
		floor.name = "floor";
		floor.AddComponent<MeshRenderer> ();
		floor.AddComponent<MeshFilter> ();
		//floor.AddComponent<Renderer> ();
		floor.GetComponent<MeshFilter> ().mesh = MakeFloor();
		floor.AddComponent<MeshCollider> ();
		//floor.GetComponent<MeshRenderer> ().material = new Material (Shader.Find("Specular"));
		floor.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.green);
		//floor.GetComponent<MeshRenderer> ().material.SetTextureScale ("Diffuse", new Vector2 (100, 0));
		//floor.renderer.material.mainTexture = Scripts.Load("grass") as Texture2D;
		//floor.GetComponent<MeshRenderer> ().material =  new Material (Shader.Find("grassMaterial"));
		//m_Material.color = Color.red;
		//floor.GetComponent<MeshRenderer> ().material = m_Material;



		for(int i = 0; i<centers.Count; ++i){
			GameObject Building = Instantiate(seed[Random.Range(0, seed.Length)], transform.position, transform.rotation);
			Building.transform.localScale = new Vector3(scale, scale, scale);
			Building.transform.localEulerAngles = new Vector3 ((float)Random.Range(-25,25)*rot, 0f, (float)Random.Range(-25,25)*rot);
			//Building.transform.localScale
			Building.transform.position=centers.ToArray()[i];
			Building.AddComponent<MeshRenderer> ();
			Building.AddComponent<MeshFilter> ();
			Building.AddComponent<MeshCollider> ();
			Building.AddComponent<CollisionsBuilding> ();
			//Building.GetComponent<MeshRenderer>().material = new Material (Shader.Find("Specular"));
			//Building.GetComponent<MeshRenderer> ().material.color = Color.green;
			Building.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.blue);
			Building.name = "building_" + i;
		}

		for(int i =0;i<(edges.Count/2);i++){
			MakeStreet (edges.ToArray()[2*i],edges.ToArray()[2*i+1],5,i);
		}
	}
	public Mesh MakeFloor(){
		List<Vector3> vertex = new List<Vector3> ();
		List<int> tri = new List<int> ();
		Mesh meshA = new Mesh();
		vertex.Add (new Vector3(floorMin.x,(float)-0.001,floorMin.z));
		vertex.Add (new Vector3(floorMax.x,(float)-0.001,0));
		vertex.Add (new Vector3(floorMax.x,(float)-0.001,floorMax.z));
		vertex.Add (new Vector3(0,(float)-0.001,floorMax.z));
		tri.Add (0);
		tri.Add (1);
		tri.Add (2);

		tri.Add (2);
		tri.Add (1);
		tri.Add (0);

		tri.Add (2);
		tri.Add (3);
		tri.Add (0);

		tri.Add (0);
		tri.Add (3);
		tri.Add (2);



		meshA.Clear ();

		meshA.vertices = vertex.ToArray();
		meshA.triangles = tri.ToArray();

		return meshA;
	}



	void MakeStreet(Vector3 a, Vector3 b, float width,int id){
		float height=Vector3.Distance(a,b);
		Mesh meshA = new Mesh();
		List<Vector3> vertex = new List<Vector3> ();
		List<int> tri = new List<int> ();


		vertex.Add (new Vector3((float)-width/2,0,(float)-height/2));
		vertex.Add (new Vector3((float)width/2,0,(float)-height/2));
		vertex.Add (new Vector3((float)width/2,0,(float)height/2));
		vertex.Add (new Vector3((float)-width/2,0,(float)height/2));
		tri.Add (0);
		tri.Add (1);
		tri.Add (2);

		tri.Add (2);
		tri.Add (1);
		tri.Add (0);

		tri.Add (0);
		tri.Add (2);
		tri.Add (3);

		tri.Add (3);
		tri.Add (2);
		tri.Add (0);

		meshA.Clear ();
		meshA.vertices = vertex.ToArray();
		meshA.triangles = tri.ToArray();
		meshA.RecalculateNormals();
		GameObject street = new GameObject ();
		street.name = "street_"+id;
		street.AddComponent<MeshRenderer> ();
		street.AddComponent<MeshFilter> ();
		street.GetComponent<MeshFilter> ().mesh = meshA;
		street.AddComponent<MeshCollider> ();
		street.GetComponent<MeshRenderer>().material.SetColor("_Color1",Color.blue);
		street.transform.position=a+(b-a)/2;
		Vector3 temp = street.transform.localScale;
		temp.y=(b - a).magnitude;
		street.transform.localScale = temp;
		street.transform.up = new Vector3 (0, 1, 0);
		street.transform.Rotate(new Vector3 (street.transform.rotation.x,Vector2.Angle(new Vector2(b.x-a.x,b.z-a.z),new Vector2(0,1)),street.transform.rotation.z));
		//Material material = new Material(Shader.Find("Specular"));
		//material.color = Color.black;
		//street.GetComponent<MeshRenderer> ().material = material;

	}


}
	