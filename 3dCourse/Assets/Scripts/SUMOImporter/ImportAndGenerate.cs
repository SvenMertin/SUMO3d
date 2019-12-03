#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using System;
using System.Xml.Serialization;
using System.IO;
using Assets.Scripts.SUMOImporter.NetFileComponents;
using Assets.Scripts;
using UnityEngine;
using System.Linq;

public class ImportAndGenerate
{

    static GameObject network;

    public static Dictionary<string, NetFileJunction> junctions;
    public static Dictionary<string, NetFileLane> lanes;
    public static Dictionary<string, NetFileEdge> edges;
    public static Dictionary<string, Shape> shapes;

    public static List<Vector3[]> polygons;

    static string sumoFilesPath;
    static string sumoBinPath;

    static float xmin;
    static float xmax;
    static float ymin;
    static float ymax;

    static Terrain Terrain;
    static TerrainData terrainData;

    static float numPlants;

    static float scaleLength = 2;
    static float scaleWidth = 2;

    static float meshScaleX = 3.3f;
    static float uvScaleV = 5;
    static float uvScaleU = 1;

    static float junctionHeight = 0.01f;
    static float trafficLightDistance = 2f;
    static float minLengthForStreetLamp = 12;
    static float streeLampDistance = 6f;

    static Boolean grassEnabled = true;
    static Boolean treesEnabled = true;

    static string[] plants = { "tree01", "tree02", "tree03", "tree04", "bush01", "bush02", "bush03", "bush04", "bush05", "bush06" };

    public static void parseXMLfiles(string sumoFilesPath)
    {
        ImportAndGenerate.sumoFilesPath = sumoFilesPath;

        network = new GameObject("StreetNetwork");

        string netFilePath = sumoFilesPath + "/map.net.xml";
        string shapesFilePath = sumoFilesPath + "/map.poly.xml";

        lanes = new Dictionary<string, NetFileLane>();
        edges = new Dictionary<string, NetFileEdge>();
        junctions = new Dictionary<string, NetFileJunction>();
        shapes = new Dictionary<string, Shape>();

        netType netFile;
        XmlSerializer serializer = new XmlSerializer(typeof(netType));
        FileStream fs = new FileStream(netFilePath, FileMode.OpenOrCreate);
        TextReader rd = new StreamReader(fs);
        netFile = (netType)serializer.Deserialize(rd);

        // Get all junctions and preinstanciate lanes
        foreach (junctionType junction in netFile.junction)
        {
            if (junction.type != junctionTypeType.@internal)
            {
                NetFileJunction j = new NetFileJunction(junction.id, junction.type, junction.x, junction.y, junction.z, junction.incLanes, junction.shape);

                // Add to global list
                if (!junctions.ContainsKey(j.id))
                    junctions.Add(j.id, j);
            }
        }

        // Get all edges and complete lane objects
        foreach (edgeType edge in netFile.edge)
        {
            if (!edge.functionSpecified)
            {
                // Only non-internal edges
                NetFileEdge e = new NetFileEdge(edge.id, edge.from, edge.to, edge.priority, edge.shape);

                // Add to global list
                if (!edges.ContainsKey(edge.id))
                    edges.Add(edge.id, e);

                foreach (laneType l in edge.lane)
                {
                    // Add all lanes which belong to this edge
                    e.addLane(l.id, l.index, l.speed, l.length, l.shape);
                }
            }
        }

        // Get map boundaries
        string[] boundaries = netFile.location.convBoundary.Split(',');
        xmin = float.Parse(boundaries[0]);
        ymin = float.Parse(boundaries[1]);
        xmax = float.Parse(boundaries[2]);
        ymax = float.Parse(boundaries[3]);


        // Now import polygons/shapes for buildings information
        additionalType additional;
        serializer = new XmlSerializer(typeof(additionalType));
        fs = new FileStream(shapesFilePath, FileMode.OpenOrCreate);
        rd = new StreamReader(fs);
		try{
	        additional = (additionalType)serializer.Deserialize(rd);		

	        // Get all junctions and preinstanciate lanes
	        foreach (object item in additional.Items)
	        {
	            if (item.GetType() == typeof(polygonType))
	            {
	                Shape shape = new Shape();
	                polygonType polygon = (polygonType)item;
	                foreach (String s in polygon.shape.Split(' '))
	                {                    
	                    shape.addCoordPair(Convert.ToDouble(s.Split(',')[0]), Convert.ToDouble(s.Split(',')[1]));
	                }
	                shape.removeLastCoordPairAndFixOrder();
	                shapes.Add(polygon.id, shape);
	            }
	        }
		}
		catch(Exception e) {
		}
    }

    internal static void openSUMOFilesAndsaveTotextFile(bool enableSUMO, bool sumoGUI, string sumoIpPort, bool enableEgoVehicle)
    {
        string storagePath = Application.dataPath;
        string projectRoot = storagePath.Substring(0, storagePath.LastIndexOf("/"));
        sumoBinPath = projectRoot.Substring(0, projectRoot.LastIndexOf("/")).Replace('/', '\\') + "\\GenerateSimulationForUnity3D\\AdditionalExecutables\\sumo-svn\\bin";

        System.IO.File.Delete(Application.dataPath + "\\Resources\\sumoBinPath.dat");
        System.IO.File.Delete(Application.dataPath + "\\Resources\\sumoFilesPath.dat");
        System.IO.File.WriteAllText(Application.dataPath + "\\Resources\\sumoBinPath.dat", sumoBinPath);
        System.IO.File.WriteAllText(Application.dataPath + "\\Resources\\sumoFilesPath.dat", sumoFilesPath);
        System.IO.File.WriteAllText(projectRoot + "\\Bin\\3dCourse_Data\\Resources\\sumoBinPath.dat", sumoBinPath);
        System.IO.File.WriteAllText(projectRoot + "\\Bin\\3dCourse_Data\\Resources\\sumoFilesPath.dat", sumoFilesPath);

        if (enableSUMO)
        {
            SUMOClient sc = GameObject.Find("StreetNetwork").AddComponent<SUMOClient>();
            sc.enableEgoVehicle = enableEgoVehicle;
            sc.remoteIpAddress = sumoIpPort.Substring(0, sumoIpPort.LastIndexOf(":"));
            sc.remotePort= sumoIpPort.Substring(sumoIpPort.LastIndexOf(":")+1);
            sc.sumoGUIEnabled = sumoGUI;
        }
    }

    public static void drawStreetNetwork()
    {
        polygons = new List<Vector3[]>();

        bool linearOption = true;

        int laneCounter = 0;
        int streetLightCounter = 0;


        // (1) Draw all Edges ------------------------------------
        MonoBehaviour.print("Inserting 3d Streets");

        foreach (NetFileEdge e in edges.Values)
        {
            int edgeCounter = 0;
            GameObject spline = new GameObject("StreetSegment_" + laneCounter++);
            spline.transform.SetParent(network.transform);

            Spline splineObject = spline.AddComponent<Spline>();

            if (linearOption)
                splineObject.interpolationMode = Spline.InterpolationMode.Linear;
            else
                splineObject.interpolationMode = Spline.InterpolationMode.BSpline;

            foreach (NetFileLane l in e.getLanes())
            {
                foreach (double[] coordPair in l.shape)
                {
                    // Add Node
                    GameObject splineNode = new GameObject("Node_" + edgeCounter++);
                    splineNode.transform.SetParent(spline.transform);
                    SplineNode splineNodeObject = splineNode.AddComponent<SplineNode>();
                    splineNode.transform.position = new Vector3((float)coordPair[0]- xmin, 0, (float)coordPair[1]-ymin);
                    splineObject.splineNodesArray.Add(splineNodeObject);
                }

                // Add meshes
                Material material = AssetDatabase.LoadAssetAtPath<Material>(PathConstants.pathRoadMaterial);
                MeshRenderer mRenderer = mRenderer = spline.GetComponent<MeshRenderer>();
                if (mRenderer == null)
                {
                    mRenderer = spline.AddComponent<MeshRenderer>();
                }
                mRenderer.material = material;


                SplineMesh sMesh = spline.AddComponent<SplineMesh>();
                sMesh.spline = splineObject;
                sMesh.baseMesh = AssetDatabase.LoadAssetAtPath<Mesh>(PathConstants.pathSuperSplinesBox);
                sMesh.startBaseMesh = AssetDatabase.LoadAssetAtPath<Mesh>(PathConstants.pathSuperSplinesBox);
                sMesh.endBaseMesh = AssetDatabase.LoadAssetAtPath<Mesh>(PathConstants.pathSuperSplinesBox);
                sMesh.uvScale = new Vector2(uvScaleU, uvScaleV);
                sMesh.xyScale = new Vector2(meshScaleX, 0);


                // (1.1) Add Lanes to polygon list for tree placement check
                for (int i = 0; i < l.shape.Count - 1; i++)
                {
                    double length = Math.Sqrt(Math.Pow(l.shape[i][0]-xmin - (l.shape[i + 1][0]-xmin), 2) + Math.Pow(l.shape[i][1]-ymin - (l.shape[i + 1][1]-ymin), 2));
                    // Calc the position (in line with the lane)
                    float x1 = (float)l.shape[i][0]-xmin;
                    float y1 = (float)l.shape[i][1]-ymin;
                    float x2 = (float)l.shape[i + 1][0] - xmin;
                    float y2 = (float)l.shape[i + 1][1] - ymin;
                    double Dx = x2 - x1;
                    double Dy = y2 - y1;
                    double D = Math.Sqrt(Dx * Dx + Dy * Dy);
                    double W = 10;
                    Dx = 0.5 * W * Dx / D;
                    Dy = 0.5 * W * Dy / D;
                    Vector3[] polygon = new Vector3[] { new Vector3((float)(x1 - Dy), 0, (float)(y1 + Dx)),
                                                    new Vector3((float)(x1 + Dy), 0, (float)(y1 - Dx)),
                                                    new Vector3((float)(x2 + Dy), 0, (float)(y2 - Dx)),
                                                    new Vector3((float)(x2 - Dy), 0, (float)(y2 + Dx)) };
                    polygons.Add(polygon);


                    // (2) Add Street Lamps (only if long enough)
                    if (length >= minLengthForStreetLamp)
                    {
                        float angle = Mathf.Atan2(y2 - y1, x2 - x1) * 180 / Mathf.PI;

                        // Allway located at the middle of a street
                        double ratioRotPoint = 0.5;
                        double ratio = 0.5 + streeLampDistance / length;

                        float xDest = (float)((1 - ratio) * x1 + ratio * x2);
                        float yDest = (float)((1 - ratio) * y1 + ratio * y2);

                        float xRotDest = (float)((1 - ratioRotPoint) * x1 + ratioRotPoint * x2);
                        float yRotDest = (float)((1 - ratioRotPoint) * y1 + ratioRotPoint * y2);

                        GameObject streetLampPrefab = AssetDatabase.LoadMainAssetAtPath(PathConstants.pathLaterne) as GameObject;
                        GameObject streetLamp = GameObject.Instantiate(streetLampPrefab, new Vector3(xDest, 0, yDest), Quaternion.Euler(new Vector3(0, 0, 0)));
                        streetLamp.name = "StreetLight_" + streetLightCounter++;
                        streetLamp.transform.SetParent(network.transform);
                        streetLamp.transform.RotateAround(new Vector3(xRotDest, 0, yRotDest), Vector3.up, -90.0f);
                        streetLamp.transform.Rotate(Vector3.up, -angle);
                    }
                }

            }


        }

        // (3) Draw all Junction areas ------------------------------------
        MonoBehaviour.print("Inserting 3d Junctions");

        int junctionCounter = 0;
        foreach (NetFileJunction j in junctions.Values)
        {
            List<int> indices = new List<int>();

            Vector2[] vertices2D = new Vector2[j.shape.Count];
            for (int i = 0; i < j.shape.Count; i++)
            {
                vertices2D[i] = new Vector3((float)(j.shape[i])[0] - xmin, (float)(j.shape[i])[1] - ymin);
            }

            // Use the triangulator to get indices for creating triangles
            Triangulator tr = new Triangulator(vertices2D);
            List<int> bottomIndices = new List<int>(tr.Triangulate());
            indices.AddRange(bottomIndices);


            // Create the Vector3 vertices
            Vector3[] vertices = new Vector3[vertices2D.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = new Vector3(vertices2D[i].x, 0, vertices2D[i].y);
            }

            Mesh mesh = new Mesh();
            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = indices.ToArray();
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            Bounds bounds = mesh.bounds;
            Vector2[] uvs = new Vector2[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                uvs[i] = new Vector2(vertices[i].x / bounds.size.x, vertices[i].z / bounds.size.z);
            }
            mesh.uv = uvs;
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            // Set up game object with mesh;
            GameObject junction3D = new GameObject("junction_" + junctionCounter++);
            MeshRenderer r = (MeshRenderer)junction3D.AddComponent(typeof(MeshRenderer));
            Material material = Resources.Load<Material>(PathConstants.pathJunctionMaterial);
            r.material = material;
            MeshFilter filter = junction3D.AddComponent(typeof(MeshFilter)) as MeshFilter;
            filter.mesh = mesh;
            junction3D.transform.SetParent(network.transform);

            // (3.1) Add junctions to polygon list for tree placement check
            polygons.Add(vertices);
        }

        // (4) Draw Traffic Lights
        MonoBehaviour.print("Inserting 3d Traffic Lights");

        foreach (NetFileJunction j in junctions.Values)
        {
            if (j.type == junctionTypeType.traffic_light)
            {
                int index = 0;
                foreach (NetFileLane l in j.incLanes)
                {
                    // Calc the position (in line with the lane)
                    float x1 = (float)l.shape[0][0] - xmin;
                    float y1 = (float)l.shape[0][1] - ymin;
                    float x2 = (float)l.shape[1][0] - xmin;
                    float y2 = (float)l.shape[1][1] - ymin;
                    float length = (float)Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2));
                    float angle = Mathf.Atan2(y2 - y1, x2 - x1) * 180 / Mathf.PI;

                    double ratio = (length - trafficLightDistance) / length;

                    float xDest = (float)((1 - ratio) * x1 + ratio * x2);
                    float yDest = (float)((1 - ratio) * y1 + ratio * y2);

                    // Insert the 3d object, rotate from lane 90° to the right side and then orientate the traffic light towards the vehicles
                    GameObject trafficLightPrefab = AssetDatabase.LoadMainAssetAtPath(PathConstants.pathTrafficLight) as GameObject;
                    GameObject trafficLight = GameObject.Instantiate(trafficLightPrefab, new Vector3(xDest, 0, yDest), Quaternion.Euler(new Vector3(0, 0, 0)));
                    trafficLight.name = "TrafficLight_" + j.id;
                    trafficLight.transform.SetParent(network.transform);
                    trafficLight.transform.RotateAround(new Vector3(x2, 0, y2), Vector3.up, -90.0f);
                    trafficLight.transform.Rotate(Vector3.up, -angle);

                    // Insert traffic light index as empty GameObject into traffic light
                    GameObject TLindex = new GameObject("index");
                    GameObject TLindexVal = new GameObject(Convert.ToString(index++));
                    TLindexVal.transform.SetParent(TLindex.transform);
                    TLindex.transform.SetParent(trafficLight.transform);
                }
            }
        }

    }

    internal static void generatingPolyBuildings()
    {
        MonoBehaviour.print("Inserting 3d Poly Buildings");

        int polyBuildingCounter = 0;        

        foreach (Shape s in shapes.Values)
        {
            // Random Bulding heights
            float randomPolyBuildingHeight = UnityEngine.Random.Range(3f, 7f);

            List<int> indices = new List<int>();

            Vector2[] vertices2D = new Vector2[s.getAllcoordPairs().Count];
            for (int i = 0; i < s.getAllcoordPairs().Count; i++)
            {
                vertices2D[i] = new Vector3((float)(s.getAllcoordPairs()[i])[0] - xmin, (float)((s.getAllcoordPairs()[i])[1] - ymin));
            }

            // Use the triangulator to get indices for creating triangles
            Triangulator tr = new Triangulator(vertices2D);
            List<int> bottomIndices = new List<int>(tr.Triangulate());
            indices.AddRange(bottomIndices);


            // Create the Vector3 vertices
            Vector3[] vertices = new Vector3[vertices2D.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = new Vector3(vertices2D[i].x-xmin, randomPolyBuildingHeight, vertices2D[i].y);
            }

            Mesh mesh = CreateMesh(vertices2D, randomPolyBuildingHeight);

            // Set up game object with unmesh;
            GameObject polyBuilding3D = new GameObject("polyBuilding_" + polyBuildingCounter++);
            MeshRenderer r = (MeshRenderer)polyBuilding3D.AddComponent(typeof(MeshRenderer));
            Material material = Resources.Load<Material>(PathConstants.pathPolyBuildingsMaterial);
            r.material = material;
            MeshFilter filter = polyBuilding3D.AddComponent(typeof(MeshFilter)) as MeshFilter;
            filter.mesh = mesh;
            polyBuilding3D.transform.SetParent(network.transform);


            // Since it's not that easy to determine the normale face, let's do it the dirty way and double the number of meshes and invert the normals for each mesh.
            // In this way it is ensured, that there are no 'open' mesh faces
            Mesh mesh_2 = CreateMesh(vertices2D, randomPolyBuildingHeight);
            Vector3[] normals = mesh_2.normals;
            for (int i = 0; i < normals.Length; i++)
                normals[i] = -normals[i];
            mesh_2.normals = normals;

            for (int m = 0; m < mesh_2.subMeshCount; m++)
            {
                int[] triangles = mesh_2.GetTriangles(m);
                for (int i = 0; i < triangles.Length; i += 3)
                {
                    int temp = triangles[i + 0];
                    triangles[i + 0] = triangles[i + 1];
                    triangles[i + 1] = temp;
                }
                mesh_2.SetTriangles(triangles, m);
            }

            // Set up game object with unmesh;
            GameObject polyBuilding3D_2 = new GameObject("polyBuilding_" + polyBuildingCounter++);
            MeshRenderer r_2 = (MeshRenderer)polyBuilding3D_2.AddComponent(typeof(MeshRenderer));
            Material material_2 = Resources.Load<Material>(PathConstants.pathPolyBuildingsMaterial);
            r_2.material = material_2;
            MeshFilter filter_2 = polyBuilding3D_2.AddComponent(typeof(MeshFilter)) as MeshFilter;
            filter_2.mesh = mesh_2;
            polyBuilding3D_2.transform.SetParent(network.transform);


            // (3.1) Add junctions to polygon list for tree placement check
            polygons.Add(vertices);


        }
    }

    static Mesh CreateMesh(Vector2[] poly, float height)
    {
        float extrusionZMinus = 0;
        float extrusionZPlus = Mathf.Max(height, 0);

        // convert polygon to triangles
        Triangulator triangulator = new Triangulator(poly);
        int[] tris = triangulator.Triangulate();
        Mesh m = new Mesh();
        Vector3[] vertices = new Vector3[poly.Length * 2];

        for (int i = 0; i < poly.Length; i++)
        {
            vertices[i].x = poly[i].x;
            vertices[i].y = extrusionZMinus;
            vertices[i].z = poly[i].y; // front vertex
            vertices[i + poly.Length].x = poly[i].x;
            vertices[i + poly.Length].y = extrusionZPlus;
            vertices[i + poly.Length].z = poly[i].y;  // back vertex    
        }
        int[] triangles = new int[tris.Length * 2 + poly.Length * 6];
        int count_tris = 0;
        for (int i = 0; i < tris.Length; i += 3)
        {
            triangles[i]     = tris[i + 2];
            triangles[i + 1] = tris[i + 1];
            triangles[i + 2] = tris[i + 0];
        } // front vertices
        count_tris += tris.Length;
        for (int i = 0; i < tris.Length; i += 3)
        {
            triangles[count_tris + i + 2] = tris[i + 2] + poly.Length;
            triangles[count_tris + i + 1] = tris[i + 1] + poly.Length;
            triangles[count_tris + i + 0] = tris[i] + poly.Length;
        } // back vertices
        count_tris += tris.Length;
        for (int i = 0; i < poly.Length; i++)
        {
            // triangles around the perimeter of the object
            int n = (i + 1) % poly.Length;
            triangles[count_tris + 0] = i;
            triangles[count_tris + 1] = n;
            triangles[count_tris + 2] = i + poly.Length;
            triangles[count_tris + 3] = n;
            triangles[count_tris + 4] = n + poly.Length;
            triangles[count_tris + 5] = i + poly.Length;
            count_tris += 6;
        }
        m.vertices = vertices;
        m.triangles = triangles;
        m.RecalculateNormals();
        m.RecalculateBounds();;
        return m;
    
}

    internal static void generatingBuildings(int count)
    {
        GameObject buildingsContainer = new GameObject("Buildings");
        
        for (int i = 0; i < count; i++)
        {
            int randomBuildingIndex = UnityEngine.Random.Range(0, PathConstants.pathBuildings.Length - 1);
            GameObject building = AssetDatabase.LoadMainAssetAtPath(PathConstants.pathBuildings[randomBuildingIndex]) as GameObject;

          Component[] renderers = building.GetComponentsInChildren<Renderer>();
            float maxLength = 0;
            float maxWidth = 0;
            foreach (Component renderer in renderers)
            {
                float currentLength=((Renderer)renderer).bounds.size.x - xmin;
                float currentWidth=((Renderer)renderer).bounds.size.z - ymin;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }
                if (currentWidth > maxWidth)
                {
                    maxWidth = currentWidth;
                }
            }
            
            maxLength=Math.Max(maxLength,maxWidth)*2f;
            maxWidth = maxLength;

            float randomXPosition = UnityEngine.Random.Range(Terrain.transform.position.x, Terrain.transform.position.x+terrainData.size.x);
            float randomYPosition = UnityEngine.Random.Range(Terrain.transform.position.z, Terrain.transform.position.z + terrainData.size.z);
            float randomOrientation = UnityEngine.Random.Range(0f, 360f);

            Boolean freeSpotFound = false;
            int counter = 0;

            while (!freeSpotFound && counter < 10)
            {
                // Try 10 random positions, if all fail, then discard this building
                int discretePointsCount = 8;
                foreach (Vector3[] polygon in polygons)
                {
                    freeSpotFound = true;
                    // Split the ground face into discretePointsCount^2 points to check
                    for (int x = 0; x < discretePointsCount; x++)
                    {
                        for (int y = 0; y < discretePointsCount; y++)
                        {
                            freeSpotFound &= !InPolyChecker.IsPointInPolygon(randomXPosition + x * maxLength / discretePointsCount, randomYPosition + y * maxLength / discretePointsCount, polygon);
                            if (!freeSpotFound)
                                break;
                        }
                    }                   
                    if (!freeSpotFound)
                        break;
                }
                if (!freeSpotFound)
                {
                    randomXPosition = UnityEngine.Random.Range(Terrain.transform.position.x, Terrain.transform.position.x + terrainData.size.x);
                    randomYPosition = UnityEngine.Random.Range(Terrain.transform.position.z, Terrain.transform.position.z + terrainData.size.z);
                    randomOrientation = UnityEngine.Random.Range(0f, 360f);
                    counter++;
                    continue;
                }

            }
            if (freeSpotFound)
            {
                GameObject instantiatedBuilding = GameObject.Instantiate(building, new Vector3(randomXPosition, 0, randomYPosition), Quaternion.Euler(new Vector3(0, randomOrientation, 0)));
                instantiatedBuilding.transform.SetParent(buildingsContainer.transform);
                Vector3[] vertices = new Vector3[] {
                    new Vector3(randomXPosition,0,randomYPosition),
                    new Vector3(randomXPosition+maxLength,0,randomYPosition),
                    new Vector3(randomXPosition+maxLength,0,randomYPosition+maxWidth),
                    new Vector3(randomXPosition,0,randomYPosition+maxWidth)
                };
                polygons.Add(vertices);
            }
        }

    }

    public static void insertEgoVehicle(Boolean udp)
    {
        GameObject egoVehicle;

        if (!udp)
        {
            egoVehicle = AssetDatabase.LoadMainAssetAtPath(PathConstants.pathEgoVehicleWASD) as GameObject;
        }
        else
        {
            egoVehicle = AssetDatabase.LoadMainAssetAtPath(PathConstants.pathEgoVehicleUDP) as GameObject;
        }


        List<NetFileLane> laneValues = new List<NetFileLane>(lanes.Values);
        NetFileLane randomLane = laneValues[UnityEngine.Random.Range(0, laneValues.Count)];
        float xMid = (float)(randomLane.shape[0][0] - xmin + randomLane.shape[1][0] - xmin) / 2;
        float yMid = (float)(randomLane.shape[0][1] - ymin + randomLane.shape[1][1] - ymin) / 2;
        float zRot = (float)((90 - Mathf.Rad2Deg * Math.Atan(((randomLane.shape[1][1] - ymin) - (randomLane.shape[0][1] - ymin)) / ((randomLane.shape[1][0] - xmin) - (randomLane.shape[0][0] - xmin)))));

        GameObject.Instantiate(egoVehicle, new Vector3(xMid, 0, yMid), Quaternion.Euler(new Vector3(0, zRot, 0)));
    }

    public static void generateTerrain(Boolean treesEnabled, Boolean grassEnabled)
    {
        ImportAndGenerate.treesEnabled = treesEnabled;
        ImportAndGenerate.grassEnabled = grassEnabled;
        int length = (int)((xmax - xmin) * scaleLength);
        int width = (int)((ymax - ymin) * scaleWidth);
        float x = xmin - (xmax - xmin) / 2 - xmin;
        float y = ymin - (ymax - ymin) / 2 - ymin;

        float height = (length < 250 || width < 250) ? 30 : 80;

        numPlants = (int)(length * width / 20);
        if (numPlants < 100)
        {
            numPlants = 500;
        }

        Texture2D FlatTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(PathConstants.pathGrassTexture2D);
        Texture2D SteepTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(PathConstants.pathRockTexture2D);

        terrainData = new TerrainData();
        terrainData.heightmapResolution = 256;
        terrainData.alphamapResolution = 256;

        var heightmap = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];
        System.Random rand = new System.Random();

        for (var zRes = 0; zRes < terrainData.heightmapResolution; zRes++)
        {
            for (var xRes = 0; xRes < terrainData.heightmapResolution; xRes++)
            {
                // Reduce factor
                float distX = 0;
                float distY = 0;
                float marginStart = 20;
                float marginEnd = 50;
                float reduceFactor = 0;
                float constHeight = 0.5f;

                if (Math.Abs(terrainData.heightmapResolution - xRes) < xRes)
                {
                    distX = Math.Abs(terrainData.heightmapResolution - xRes);
                }
                else
                {
                    distX = xRes;
                }
                if (Math.Abs(terrainData.heightmapResolution - zRes) < zRes)
                {
                    distY = Math.Abs(terrainData.heightmapResolution - zRes);
                }
                else
                {
                    distY = zRes;
                }

                if (distX > marginStart && distY > marginStart && distX <= marginEnd && distY <= marginEnd)
                {
                    reduceFactor = 1 - (float)(((distX - marginStart) + (distY - marginStart)) / (2 * (marginEnd - marginStart)));
                    heightmap[zRes, xRes] = reduceFactor * constHeight;
                }
                else if (distY > marginStart && distY <= marginEnd && distX > marginEnd)
                {
                    reduceFactor = 1 - ((distY - marginStart) / (marginEnd - marginStart));
                    heightmap[zRes, xRes] = reduceFactor * constHeight;
                }
                else if (distX > marginStart && distX <= marginEnd && distY > marginEnd)
                {
                    reduceFactor = 1 - ((distX - marginStart) / (marginEnd - marginStart));
                    heightmap[zRes, xRes] = reduceFactor * constHeight;
                }
                else
                {
                    reduceFactor = 1;
                    heightmap[zRes, xRes] = reduceFactor * constHeight;
                }

                // Actual height values from neighbours

                double randFactor = 0.1f;
                double selfFactor = 1.5;
                float value = 0;

                if (zRes > 0 && xRes > 0 && xRes < terrainData.heightmapResolution - 1 && zRes < terrainData.heightmapResolution - 1)
                {
                    value = (float)(
                       heightmap[zRes, xRes] * selfFactor +
                       rand.NextDouble() * randFactor +
                       heightmap[zRes - 1, xRes - 1] +
                       heightmap[zRes, xRes - 1] +
                       heightmap[zRes - 1, xRes] +
                       heightmap[zRes + 1, xRes - 1] +
                       heightmap[zRes - 1, xRes + 1] +
                       heightmap[zRes + 1, xRes + 1] +
                       heightmap[zRes + 1, xRes] +
                       heightmap[zRes, xRes + 1]) / 10;
                }
                else if (xRes == 0 && zRes == 0)
                {
                    value = (float)(
                        heightmap[zRes, xRes] * selfFactor +
                        rand.NextDouble() * randFactor +
                        heightmap[zRes + 1, xRes + 1] +
                        heightmap[zRes + 1, xRes] +
                        heightmap[zRes, xRes + 1]) / 5;
                }
                else if (xRes == 0 && zRes > 0 && zRes < terrainData.heightmapResolution - 1)
                {
                    value = (float)(
                        heightmap[zRes, xRes] * selfFactor +
                        rand.NextDouble() * randFactor +
                        heightmap[zRes - 1, xRes] +
                        heightmap[zRes - 1, xRes + 1] +
                        heightmap[zRes + 1, xRes + 1] +
                        heightmap[zRes + 1, xRes] +
                        heightmap[zRes, xRes + 1]) / 7;
                }
                else if (xRes == 0 && zRes == terrainData.heightmapResolution - 1)
                {
                    value = (float)(
                        heightmap[zRes, xRes] * selfFactor +
                        rand.NextDouble() * randFactor * randFactor +
                        heightmap[zRes - 1, xRes] +
                        heightmap[zRes - 1, xRes + 1] +
                        heightmap[zRes, xRes + 1]) / 5;
                }
                else if (xRes > 0 && xRes < terrainData.heightmapResolution - 1 && zRes == 0)
                {
                    value = (float)(
                        heightmap[zRes, xRes] * selfFactor +
                        rand.NextDouble() * randFactor +
                        heightmap[zRes, xRes - 1] +
                        heightmap[zRes + 1, xRes - 1] +
                        heightmap[zRes + 1, xRes + 1] +
                        heightmap[zRes + 1, xRes] +
                        heightmap[zRes, xRes + 1]) / 7;

                }
                else if (xRes == terrainData.heightmapResolution - 1 && zRes == 0)
                {
                    value = (float)(
                        heightmap[zRes, xRes] * selfFactor +
                        rand.NextDouble() * randFactor +
                        heightmap[zRes, xRes - 1] +
                        heightmap[zRes + 1, xRes - 1] +
                        heightmap[zRes + 1, xRes]) / 5;
                }
                else if (xRes == terrainData.heightmapResolution - 1 && zRes > 0 && zRes < terrainData.heightmapResolution - 1)
                {
                    value = (float)(
                        heightmap[zRes, xRes] * selfFactor +
                        rand.NextDouble() * randFactor +
                        heightmap[zRes - 1, xRes - 1] +
                        heightmap[zRes, xRes - 1] +
                        heightmap[zRes - 1, xRes] +
                        heightmap[zRes + 1, xRes - 1] +
                        heightmap[zRes + 1, xRes]) / 7;
                }
                else if (xRes == terrainData.heightmapResolution - 1 && zRes == terrainData.heightmapResolution - 1)
                {
                    value = (float)(
                        heightmap[zRes, xRes] * selfFactor +
                        rand.NextDouble() * randFactor +
                        heightmap[zRes - 1, xRes - 1] +
                        heightmap[zRes, xRes - 1] +
                        heightmap[zRes - 1, xRes]) / 5;
                }
                else if (xRes > 0 && xRes < terrainData.heightmapResolution - 1 && zRes == terrainData.heightmapResolution - 1)
                {
                    value = (float)(
                        heightmap[zRes, xRes] * selfFactor +
                        rand.NextDouble() * randFactor +
                        heightmap[zRes - 1, xRes - 1] +
                        heightmap[zRes, xRes - 1] +
                        heightmap[zRes - 1, xRes] +
                        heightmap[zRes - 1, xRes + 1] +
                        heightmap[zRes, xRes + 1]) / 7;
                }

                if (value < 0 || distX > marginEnd && distY > marginEnd)
                {
                    value = 0;
                }

                heightmap[zRes, xRes] = value;

            }
        }

        terrainData.SetHeights(0, 0, heightmap);

        var flatSplat = new SplatPrototype();
        var steepSplat = new SplatPrototype();

        flatSplat.texture = FlatTexture;
        steepSplat.texture = SteepTexture;

        terrainData.splatPrototypes = new SplatPrototype[]
        {
                flatSplat,
                steepSplat
        };

        terrainData.RefreshPrototypes();

        var splatMap = new float[terrainData.alphamapResolution, terrainData.alphamapResolution, 2];

        for (var zRes = 0; zRes < terrainData.alphamapHeight; zRes++)
        {
            for (var xRes = 0; xRes < terrainData.alphamapWidth; xRes++)
            {
                var normalizedX = (float)xRes / (terrainData.alphamapWidth - 1);
                var normalizedZ = (float)zRes / (terrainData.alphamapHeight - 1);

                var steepness = terrainData.GetSteepness(normalizedX, normalizedZ);
                var steepnessNormalized = Mathf.Clamp(steepness / 1.5f, 0, 1f);

                splatMap[zRes, xRes, 0] = 1f - steepnessNormalized;
                splatMap[zRes, xRes, 1] = steepnessNormalized;
            }
        }

        terrainData.SetAlphamaps(0, 0, splatMap);

        terrainData.size = new Vector3(length, height, width);
        var newTerrainGameObject = Terrain.CreateTerrainGameObject(terrainData);
        newTerrainGameObject.transform.position = new Vector3(x, 0, y);

        Terrain = newTerrainGameObject.GetComponent<Terrain>();
        Terrain.heightmapPixelError = 8;
        Terrain.materialType = UnityEngine.Terrain.MaterialType.Custom;
        Terrain.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;

        // Insert Trees and Plants
        if (ImportAndGenerate.treesEnabled)
        {
            // (1) Trees:

            MonoBehaviour.print("Inserting 3d Plants");

            List<TreePrototype> tpa = new List<TreePrototype>();

            for (int i = 0; i < plants.Length; i++)
            {
                TreePrototype tp = new TreePrototype();
                tp.prefab = AssetDatabase.LoadMainAssetAtPath(PathConstants.pathPrefixPlants + plants[i] + ".prefab") as GameObject;
                tpa.Add(tp);
            }
            terrainData.treePrototypes = tpa.ToArray();

            for (int i = 0; i < numPlants; i++)
            {
                float xnRel = (float)rand.NextDouble();
                float xn = terrainData.size.x * xnRel;
                float ynRel = (float)rand.NextDouble();
                float yn = terrainData.size.z * ynRel;

                float xGlobal = Terrain.transform.TransformPoint(new Vector3(xn, 0, yn)).x;
                float yGlobal = Terrain.transform.TransformPoint(new Vector3(xn, 0, yn)).z;

                Boolean freeSpotFound = false;
                int counter = 0;

                while (!freeSpotFound && counter < 10)
                {
                    // Try 10 random positions, if all fail, then discard this plant
                    foreach (Vector3[] polygon in polygons)
                    {
                        freeSpotFound = !InPolyChecker.IsPointInPolygon(xGlobal, yGlobal, polygon);
                        if (!freeSpotFound)
                            break;
                    }
                    if (!freeSpotFound)
                    {
                        xnRel = (float)rand.NextDouble();
                        xn = terrainData.size.x * xnRel;
                        ynRel = (float)rand.NextDouble();
                        yn = terrainData.size.z * ynRel;

                        xGlobal = Terrain.transform.TransformPoint(new Vector3(xn, 0, yn)).x;
                        yGlobal = Terrain.transform.TransformPoint(new Vector3(xn, 0, yn)).z;

                        counter++;
                        break;
                    }

                }
                if (freeSpotFound)
                {
                    TreeInstance tree = new TreeInstance();
                    tree.position = new Vector3(xnRel, 0, ynRel);
                    tree.color = Color.white;
                    tree.lightmapColor = Color.white;
                    tree.prototypeIndex = rand.Next(0, plants.Length);
                    tree.heightScale = 1;
                    tree.widthScale = 1;
                    Terrain.AddTreeInstance(tree);
                }
            }
        }

        // (2) Grass:
        if (ImportAndGenerate.grassEnabled)
        {
            DetailPrototype grass = new DetailPrototype();
            grass.prototypeTexture = (Texture2D)AssetDatabase.LoadAssetAtPath<Texture2D>(PathConstants.pathGrassPrototypeTexture2D);
            grass.minHeight = 1;
            grass.minWidth = 1;
            grass.maxHeight = 2;
            grass.maxWidth = 2;
            grass.noiseSpread = 0.1f;
            grass.bendFactor = 0.1f;
            grass.dryColor = new Color(0.804f, 0.737f, 0.102f, 1.0f);
            grass.healthyColor = new Color(0.263f, 0.976f, 0.165f, 1.0f);

            terrainData.detailPrototypes = new DetailPrototype[] { grass };
            terrainData.SetDetailResolution(256, 8);

            int detailCountPerDetailPixel = 6;
            int detailIndexToMassPlace = 0;
            int alphamapWidth = terrainData.alphamapWidth;
            int alphamapHeight = terrainData.alphamapHeight;
            int detailWidth = terrainData.detailResolution;
            int detailHeight = detailWidth;
            int[,] newDetailLayer = new int[detailWidth, detailHeight];
            int delta = 1;

            for (int j = 0; j < detailWidth; j++)
            {
                for (int k = 0; k < detailHeight; k++)
                {
                    float[] coord = getCornerCoordinatesFromPixel(j, k, detailWidth, detailHeight, Terrain.gameObject.transform.position.x, Terrain.gameObject.transform.position.z, terrainData.size.x, terrainData.size.z);
                    // Check if there is a street/junction at the coordinate
                    Boolean occupied = false;
                    foreach (Vector3[] polygon in polygons)
                    {
                        // Check sorrounding of coordinate
                        occupied = InPolyChecker.IsPointInPolygon(coord[0], coord[1], polygon) ||
                                        InPolyChecker.IsPointInPolygon(coord[0] - delta, coord[1] - delta, polygon) ||
                                        InPolyChecker.IsPointInPolygon(coord[0] - delta, coord[1], polygon) ||
                                        InPolyChecker.IsPointInPolygon(coord[0] - delta, coord[1] + delta, polygon) ||
                                        InPolyChecker.IsPointInPolygon(coord[0] + delta, coord[1] - delta, polygon) ||
                                        InPolyChecker.IsPointInPolygon(coord[0] + delta, coord[1], polygon) ||
                                        InPolyChecker.IsPointInPolygon(coord[0] + delta, coord[1] + delta, polygon);
                        if (occupied)
                            break;
                    }
                    if (!occupied)
                    {
                        newDetailLayer[j, k] = detailCountPerDetailPixel;
                    }
                }
            }
            terrainData.SetDetailLayer(0, 0, detailIndexToMassPlace, newDetailLayer);
        }

        // Finish
        Terrain.Flush();
    }

    private static float[] getCornerCoordinatesFromPixel(int xIndex, int yIndex, int pixelWidth, int pixelHeight, float xTerrain, float yTerrain, float lengthTerrain, float widthTerrain)
    {
        float[] coord = new float[2];
        if (lengthTerrain <= widthTerrain)
        {
            coord[0] = (float)((float)(yIndex) / (float)(pixelHeight - 1)) * Math.Min(widthTerrain, lengthTerrain) + Math.Max(xTerrain, yTerrain);
            coord[1] = (float)((float)(xIndex) / (float)(pixelWidth - 1)) * Math.Max(widthTerrain, lengthTerrain) + Math.Min(xTerrain, yTerrain);
        }
        else
        {
            coord[0] = (float)((float)(yIndex) / (float)(pixelHeight - 1)) * Math.Max(widthTerrain, lengthTerrain) + Math.Min(xTerrain, yTerrain);
            coord[1] = (float)((float)(xIndex) / (float)(pixelWidth - 1)) * Math.Min(widthTerrain, lengthTerrain) + Math.Max(xTerrain, yTerrain);
        }
        return coord;
    }
    
    public static void addCameraScript()
    {
        // Insert static cameras
        GameObject camera0 = new GameObject("Camera0");
        camera0.transform.position = new Vector3((xmax - xmin) / 2 - xmin, 200, (ymax - ymin) / 2 - ymin);
        camera0.transform.Rotate(new Vector3(90, 0, 0));
        Camera cam0 = camera0.AddComponent<Camera>();
        camera0.SetActive(true);

        GameObject camera1 = new GameObject("Camera1");
        Camera cam1 = camera1.AddComponent<Camera>();
        camera1.transform.position = new Vector3((float)(xmin + (xmax - xmin) * 0.2 - xmin), 70, (float)(ymin + (ymax - ymin) * 0.2 - ymin));
        camera1.transform.Rotate(new Vector3(60, 45, 0));
        camera1.SetActive(true);

        GameObject camera2 = new GameObject("Camera2");
        Camera cam2 = camera2.AddComponent<Camera>();
        camera2.transform.position = new Vector3((float)(xmin + 0.35 * (xmax - xmin)-xmin) - xmin, 10, (float)(ymin + 0.35 * (ymax - ymin) - ymin));
        camera2.transform.Rotate(new Vector3(UnityEngine.Random.Range(20, 35), UnityEngine.Random.Range(0, 360), 0));
        camera2.SetActive(true);

        GameObject camera3 = new GameObject("Camera3");
        Camera cam3 = camera3.AddComponent<Camera>();
        camera3.transform.position = new Vector3((float)(xmin + UnityEngine.Random.Range(0.1f, 0.8f) * (xmax - xmin) - xmin), 15, (float)(ymin + UnityEngine.Random.Range(0.1f, 0.8f) * (ymax - ymin)) - ymin);
        camera3.transform.Rotate(new Vector3(UnityEngine.Random.Range(15, 45), UnityEngine.Random.Range(0, 360), 0));
        camera3.SetActive(true);

        GameObject.Find("StreetNetwork").AddComponent<MixedStaticAndForeignCameraChanger>();
    }
}

#endif