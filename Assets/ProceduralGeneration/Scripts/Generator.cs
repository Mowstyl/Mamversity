using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject[] seed;
    public float scale = 1;
	public List<Vector3> centers=new List<Vector3>();
	public List<Vector3> edges=new List<Vector3>();
	public Vector3 floorMax;
	public Vector3 floorMin;

	// Use this for initialization
	public void Start () {
		
        Generate();

	}
	
	// Update is called once per frame
	public void Generate () {
		
		/*GameObject thePlayer = GameObject.Find("VoronoiDemo");
		VoronoiDemo playerScript = thePlayer.GetComponent<VoronoiDemo>();*/
		GameObject floor = new GameObject ();
		floor.name = "floor";
		floor.AddComponent<MeshRenderer> ();
		floor.AddComponent<MeshFilter> ();
		floor.AddComponent<MeshCollider> ();
		floor.GetComponent<MeshFilter> ().mesh = MakeFloor();
		floor.GetComponent<MeshRenderer> ().material = new Material (Shader.Find("Specular"));
		//floor.GetComponent<MeshRenderer> ().material.SetTextureScale ("Diffuse", new Vector2 (100, 0));
		//floor.renderer.material.mainTexture = Resources.Load("Floor") as Texture2D;



		for(int i = 0; i<centers.Count; ++i){
			GameObject Building = Instantiate(seed[Random.Range(0, seed.Length)], transform.position, transform.rotation);
			Building.transform.localScale = new Vector3(scale, scale, scale);
			//Building.transform.localScale
			Building.transform.position=centers.ToArray()[i];
			Building.AddComponent<MeshRenderer> ();
			Building.AddComponent<MeshCollider> ();
			Building.GetComponent<MeshRenderer>().material = new Material (Shader.Find("Specular"));
		}
		for(int i =0;i<(edges.Count/2);i++){
			MakeStreet (edges.ToArray()[2*i],edges.ToArray()[2*i+1],5,i);
		}


		/*for (int i = 0; i < playerScript.centers.Count; i++){
			GameObject building = new GameObject ();
			building.name = "building_" + i;
			//building.AddComponent<MeshRenderer> ();
			//building.AddComponent<MeshFilter> ();
			//building.AddComponent<Generator> ();
			building.transform.position=centers.ToArray()[i];
		}*/
		/*GameObject Building = Instantiate(seed[Random.Range(0, seed.Length)], transform.position, transform.rotation);
		Building.transform.localScale = new Vector3(scale, scale, scale);*/
	}
	public Mesh MakeFloor(){
		List<Vector3> vertex = new List<Vector3> ();
		List<int> tri = new List<int> ();
		Mesh meshA = new Mesh();
		vertex.Add (new Vector3(floorMin.x,(float)-0.001,floorMin.z));
		vertex.Add (new Vector3(floorMax.x,(float)-0.001,0));
		vertex.Add (new Vector3(floorMax.x,(float)-0.001,floorMax.z));
		vertex.Add (new Vector3(0,(float)-0.001,floorMax.z));
		Color[] colors = new Color[vertex.ToArray ().Length];
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

		//meshA.RecalculateNormals();

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
		street.transform.position=a+(b-a)/2;
		Vector3 temp = street.transform.localScale;
		temp.y=(b - a).magnitude;
		street.transform.localScale = temp;
		street.transform.up = new Vector3 (0, 1, 0);
		street.transform.Rotate(new Vector3 (street.transform.rotation.x,Vector2.Angle(new Vector2(b.x-a.x,b.z-a.z),new Vector2(0,1)),street.transform.rotation.z));
		Material material = new Material(Shader.Find("Specular"));
		material.color = Color.black;
		street.GetComponent<MeshRenderer> ().material = material;
	}


}
