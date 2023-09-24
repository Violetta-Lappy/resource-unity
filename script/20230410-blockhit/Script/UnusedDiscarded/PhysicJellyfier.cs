using UnityEngine;

public class PhysicJellyfier : MonoBehaviour {
    [Header("Bouncy Value")]
    public float f_bounceSpeed;
    public float f_fallForce;    
    public float stiffness; //We need this value to eventually stop bouncing back and forth.
    
    private MeshFilter meshFilter;
    private Mesh mesh;
    
    Vector3[] initialVertices;
    Vector3[] currentVertices;
    Vector3[] vertexVelocities;

    private void Start() {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        f_fallForce = Random.Range(25, 80); //def: 25 - 80
        
        initialVertices = mesh.vertices;
        
        //Initialize 2 arrays
        currentVertices = new Vector3[initialVertices.Length];
        vertexVelocities = new Vector3[initialVertices.Length];
        for (int i = 0; i < initialVertices.Length; i++) currentVertices[i] = initialVertices[i];
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.K)) ApplyPressureToPoint(Vector3.one, f_fallForce);

        UpdateVertices(); 
    }

    private void UpdateVertices() {        
        for (int i = 0; i < currentVertices.Length; i++) {            
            Vector3 currentDisplacement = currentVertices[i] - initialVertices[i];
            vertexVelocities[i] -= currentDisplacement * f_bounceSpeed * Time.deltaTime;

            //Stop bouncing at one point we need to reduce the velocity over time. 
            vertexVelocities[i] *= 1f - stiffness * Time.deltaTime;
            currentVertices[i] += vertexVelocities[i] * Time.deltaTime;
        }

        //We then need to set our mesh.vertices to the current vertices 
        //in order to be able to see a change.
        mesh.vertices = currentVertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

    }

    public void OnCollisionEnter(Collision other) {
        ContactPoint[] collisonPoints = other.contacts;
        for (int i = 0; i < collisonPoints.Length; i++) {
            Vector3 inputPoint = collisonPoints[i].point + (collisonPoints[i].point * .1f);
            ApplyPressureToPoint(inputPoint, f_fallForce);
        }
    }

    public void AddCollision(Collision other) {
        ContactPoint[] collisonPoints = other.contacts;
        for (int i = 0; i < collisonPoints.Length; i++) {
            Vector3 inputPoint = collisonPoints[i].point + (collisonPoints[i].point * .1f);
            ApplyPressureToPoint(inputPoint, f_fallForce);
        }
    }

    public void ApplyPressureToPoint(Vector3 _point, float _pressure) {
        //We need to loop through every single vertice and apply the pressure to it.
        for (int i = 0; i < currentVertices.Length; i++) ApplyPressureToVertex(i, _point, _pressure);
    }

    public void ApplyPressureToVertex(int _index, Vector3 _position, float _pressure) {        
        
        Vector3 distanceVerticePoint = currentVertices[_index] - transform.InverseTransformPoint(_position);
        
        float adaptedPressure = _pressure / (1f + distanceVerticePoint.sqrMagnitude);
        
        float velocity = adaptedPressure * Time.deltaTime;
        
        vertexVelocities[_index] += distanceVerticePoint.normalized * velocity;
    }
}