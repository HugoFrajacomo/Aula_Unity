using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chunk
{
    public static readonly int largura = 16;
    public static readonly int altura = 100;
    public int lado;

    private ChunkPos pos;

    private Mesh mesh;
    private List<Vector3> vertices = new List<Vector3>();
    private List<int> triangles = new List<int>();
    private List<Vector2> UV = new List<Vector2>();
    public GameObject go;
    private MeshFilter filter;
    private MeshRenderer render;
    private MeshCollider Colisao;
    public Material textura;

    private ushort[] blocos;


    public Chunk(ChunkPos pos, Material textura)
    {
        this.blocos = new ushort[largura*largura*altura];
        this.pos = pos;
        this.textura = textura;
    }

    public void Gerar()
    {
        int nivel;

        for (int x = 0; x< largura; x++)
        {
            for (int z = 0; z< largura; z++)
            {
                for (int y = 0; y < altura; y++)
                {
                    float sinValue = Mathf.Sin((x /*+ pos.x*/) * 0.1f) + Mathf.Sin((y /*+ pos.y*/) * 0.2f) + Mathf.Sin((z /*+ pos.z*/) * 0.1f);
                    nivel = Mathf.FloorToInt(sinValue * 5) + 20;

                    if (y <= nivel)
                    {
                        this.blocos[GetIndex(x, y, z)] = 1;
                    }
                    else
                    {
                        this.blocos[GetIndex(x, y, z)] = 0;
                    }
                }
            }
        }
    }

    public void Construir()
    {
        //variáveis
        ushort esseBloco;
        ushort blocoAtual;
        int num_vertices;

        for (int x = 0; x < largura; x++)
        {
            for (int z = 0; z < largura; z++)
            {
                for (int y = 0; y < altura; y++)
                {
                    esseBloco = this.blocos[GetIndex(x, y, z)];
                    //checando se deve ser desenhado
                    if (esseBloco == 0)
                        continue;

                    // Iterando por todos os lados
                    for (int dir = 0; dir <= 5; dir++)
                    {
                        switch (dir)
                        {
                            case 0:
                                if (y < altura - 1) 
                                {
                                    blocoAtual = this.blocos[GetIndex(x, y + 1, z)];
                                    if (blocoAtual == 0) {
                                            num_vertices = this.vertices.Count;
                                        ExecutarDesenho(dir, num_vertices, x, y, z, esseBloco);
                                    }
                                }
                                break;
                            case 1:
                                if (y > 0)
                                {
                                    blocoAtual = this.blocos[GetIndex(x, y - 1, z)];
                                    if (blocoAtual == 0)
                                    {
                                        num_vertices = this.vertices.Count;
                                        ExecutarDesenho(dir, num_vertices, x, y, z, esseBloco);
                                    }
                                }
                                break;
                            case 2:
                                if (x < largura - 1)
                                {
                                    blocoAtual = this.blocos[GetIndex(x + 1, y, z)];
                                    if (blocoAtual == 0)
                                    {
                                        num_vertices = this.vertices.Count;
                                        ExecutarDesenho(dir, num_vertices, x, y, z, esseBloco);
                                    }
                                }
                                break;
                            case 3:
                                if (x > 0)
                                {
                                    blocoAtual = this.blocos[GetIndex(x - 1, y, z)];
                                    if (blocoAtual == 0)
                                    {
                                        num_vertices = this.vertices.Count;
                                        ExecutarDesenho(dir, num_vertices, x, y, z, esseBloco);
                                    }
                                }
                                break;
                            case 4:
                                if (z < largura - 1)
                                {
                                    blocoAtual = this.blocos[GetIndex(x, y, z + 1)];
                                    if (blocoAtual == 0)
                                    {
                                        num_vertices = this.vertices.Count;
                                        ExecutarDesenho(dir, num_vertices, x, y, z, esseBloco);
                                    }
                                }
                                break;
                            case 5:
                                if (z > 0)
                                {
                                    blocoAtual = this.blocos[GetIndex(x, y, z - 1)];
                                    if (blocoAtual == 0)
                                    {
                                        num_vertices = this.vertices.Count;
                                        ExecutarDesenho(dir, num_vertices, x, y, z, esseBloco);
                                    }
                                }
                                break;
                            default:
                                blocoAtual = 0;
                                break;
                        }
                    }
                }
            }
        }

        this.mesh = new Mesh();
        this.mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        this.mesh.SetVertices(vertices);
        this.mesh.SetTriangles(triangles, 0);
        this.mesh.SetUVs(0, this.UV);
        this.mesh.RecalculateNormals();  

        this.go = new GameObject();
        this.go.transform.position = new Vector3(pos.x * largura, 0f, pos.z * largura);
        this.go.layer = 6;
        this.filter = this.go.AddComponent<MeshFilter>();
        this.render = this.go.AddComponent<MeshRenderer>();
        this.render.material = this.textura;
        this.Colisao = this.go.AddComponent<MeshCollider>();
        this.filter.sharedMesh = this.mesh;
        this.Colisao.sharedMesh = this.mesh;

    }

    public int GetIndex(int x, int y, int z)
    {
        return x * largura * altura + y * largura + z;
    }

    public void ExecutarDesenho(int dir, int num_vertices, int x, int y, int z, ushort idBlock)
    {
        //x += nextChunkx * largura;
        this.vertices.AddRange(QuadGeneretor.GetVertices(dir, new Vector3(x,y,z)));
        this.triangles.AddRange(QuadGeneretor.GetTriangles(num_vertices));
        this.UV.AddRange(Block.GetUVs(idBlock));

    }
}

